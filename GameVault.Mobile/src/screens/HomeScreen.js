import React, { useState, useCallback } from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet, Image } from 'react-native';
import { useFocusEffect } from '@react-navigation/native';
import { getGames } from '../services/gameService';

export default function HomeScreen({ navigation }) {
  const [games, setGames] = useState([]);
  const [loading, setLoading] = useState(true);

  useFocusEffect(
    useCallback(() => {
      loadGames();
    }, [])
  );

  const loadGames = async () => {
    try {
      const res = await getGames();
      setGames(res.data);
    } catch (e) {
      console.log('Błąd ładowania gier:', e);
    }
    setLoading(false);
  };

  const renderGame = ({ item }) => (
    <TouchableOpacity style={styles.card} onPress={() => navigation.navigate('GameDetail', { gameId: item.id })}>
      <View style={styles.imageBox}>
        <Text style={styles.emoji}>🎮</Text>
      </View>
      <View style={styles.info}>
        <Text style={styles.title}>{item.title}</Text>
        <Text style={styles.publisher}>{item.publisher?.name}</Text>
        <Text style={styles.price}>{item.price === 0 ? 'Free' : `${item.price} PLN`}</Text>
      </View>
    </TouchableOpacity>
  );

  return (
    <View style={styles.container}>
      <Text style={styles.header}>Sklep z grami</Text>
      <FlatList
        data={games}
        keyExtractor={(item) => item.id.toString()}
        renderItem={renderGame}
        refreshing={loading}
        onRefresh={loadGames}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#1a1a2e', paddingTop: 50 },
  header: { fontSize: 28, fontWeight: 'bold', color: '#e94560', paddingHorizontal: 20, marginBottom: 15 },
  card: { flexDirection: 'row', backgroundColor: '#16213e', marginHorizontal: 15, marginBottom: 10, borderRadius: 12, overflow: 'hidden' },
  imageBox: { width: 80, height: 80, backgroundColor: '#0f3460', justifyContent: 'center', alignItems: 'center' },
  emoji: { fontSize: 30 },
  info: { flex: 1, padding: 12, justifyContent: 'center' },
  title: { color: '#fff', fontSize: 16, fontWeight: 'bold' },
  publisher: { color: '#888', fontSize: 13, marginTop: 2 },
  price: { color: '#e94560', fontSize: 15, fontWeight: 'bold', marginTop: 4 }
});