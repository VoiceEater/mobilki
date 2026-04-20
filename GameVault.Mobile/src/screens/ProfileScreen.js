import React, { useState, useCallback } from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet, Alert } from 'react-native';
import { useFocusEffect } from '@react-navigation/native';
import { getUser, logout } from '../services/authService';
import { getWishlist, removeFromWishlist } from '../services/wishlistService';

export default function ProfileScreen({ navigation }) {
  const [user, setUser] = useState(null);
  const [wishlist, setWishlist] = useState([]);

  useFocusEffect(
    useCallback(() => {
      loadProfile();
    }, [])
  );

  const loadProfile = async () => {
    const userData = await getUser();
    setUser(userData);
    if (userData) {
      try {
        const res = await getWishlist(userData.id);
        setWishlist(res.data);
      } catch (e) {
        console.log('Błąd wishlist:', e);
      }
    }
  };

  const handleLogout = async () => {
    await logout();
    navigation.reset({ index: 0, routes: [{ name: 'Login' }] });
  };

  const handleRemoveWishlist = async (id) => {
    try {
      await removeFromWishlist(id);
      loadProfile();
    } catch (e) {
      Alert.alert('Błąd', 'Nie udało się usunąć');
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.header}>Profil</Text>
      {user && (
        <View style={styles.userCard}>
          <Text style={styles.username}>{user.username}</Text>
          <Text style={styles.email}>{user.email}</Text>
          <Text style={styles.role}>{user.role}</Text>
        </View>
      )}

      <Text style={styles.sectionTitle}>Lista życzeń</Text>
      <FlatList
        data={wishlist}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <View style={styles.wishItem}>
            <Text style={styles.wishTitle}>🎮 {item.game?.title}</Text>
            <TouchableOpacity onPress={() => handleRemoveWishlist(item.id)}>
              <Text style={styles.removeBtn}>✕</Text>
            </TouchableOpacity>
          </View>
        )}
        ListEmptyComponent={<Text style={styles.empty}>Lista życzeń jest pusta</Text>}
      />

      <TouchableOpacity style={styles.logoutBtn} onPress={handleLogout}>
        <Text style={styles.logoutText}>Wyloguj się</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#1a1a2e', paddingTop: 50 },
  header: { fontSize: 28, fontWeight: 'bold', color: '#e94560', paddingHorizontal: 20, marginBottom: 15 },
  userCard: { backgroundColor: '#16213e', marginHorizontal: 15, padding: 20, borderRadius: 12, marginBottom: 20 },
  username: { color: '#fff', fontSize: 22, fontWeight: 'bold' },
  email: { color: '#888', fontSize: 14, marginTop: 4 },
  role: { color: '#e94560', fontSize: 12, marginTop: 4, textTransform: 'uppercase' },
  sectionTitle: { fontSize: 18, fontWeight: 'bold', color: '#e94560', paddingHorizontal: 20, marginBottom: 10 },
  wishItem: { backgroundColor: '#16213e', marginHorizontal: 15, marginBottom: 8, padding: 12, borderRadius: 10, flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center' },
  wishTitle: { color: '#fff', fontSize: 14 },
  removeBtn: { color: '#e94560', fontSize: 18, fontWeight: 'bold' },
  empty: { color: '#888', textAlign: 'center', marginTop: 20 },
  logoutBtn: { margin: 20, backgroundColor: '#e94560', padding: 15, borderRadius: 10, alignItems: 'center' },
  logoutText: { color: '#fff', fontSize: 16, fontWeight: 'bold' }
});