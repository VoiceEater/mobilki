import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Alert } from 'react-native';
import { register } from '../services/authService';

export default function RegisterScreen({ navigation }) {
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);

  const handleRegister = async () => {
    if (!username || !email || !password) return Alert.alert('Błąd', 'Wypełnij wszystkie pola');
    setLoading(true);
    try {
      await register(username, email, password);
      Alert.alert('Sukces', 'Konto utworzone! Zaloguj się');
      navigation.goBack();
    } catch (e) {
      Alert.alert('Błąd', 'Rejestracja nie powiodła się');
    }
    setLoading(false);
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>GameVault</Text>
      <Text style={styles.subtitle}>Rejestracja</Text>
      <TextInput style={styles.input} placeholder="Nazwa użytkownika" placeholderTextColor="#888" value={username} onChangeText={setUsername} />
      <TextInput style={styles.input} placeholder="Email" placeholderTextColor="#888" value={email} onChangeText={setEmail} keyboardType="email-address" autoCapitalize="none" />
      <TextInput style={styles.input} placeholder="Hasło" placeholderTextColor="#888" value={password} onChangeText={setPassword} secureTextEntry />
      <TouchableOpacity style={styles.button} onPress={handleRegister} disabled={loading}>
        <Text style={styles.buttonText}>{loading ? 'Rejestracja...' : 'Zarejestruj'}</Text>
      </TouchableOpacity>
      <TouchableOpacity onPress={() => navigation.goBack()}>
        <Text style={styles.link}>Masz konto? Zaloguj się</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#1a1a2e', justifyContent: 'center', padding: 30 },
  title: { fontSize: 36, fontWeight: 'bold', color: '#e94560', textAlign: 'center', marginBottom: 5 },
  subtitle: { fontSize: 16, color: '#aaa', textAlign: 'center', marginBottom: 30 },
  input: { backgroundColor: '#16213e', color: '#fff', padding: 15, borderRadius: 10, marginBottom: 15, fontSize: 16 },
  button: { backgroundColor: '#e94560', padding: 15, borderRadius: 10, alignItems: 'center', marginBottom: 15 },
  buttonText: { color: '#fff', fontSize: 18, fontWeight: 'bold' },
  link: { color: '#e94560', textAlign: 'center', fontSize: 14 }
});