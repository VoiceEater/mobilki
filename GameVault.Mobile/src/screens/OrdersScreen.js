import React, { useState, useCallback } from 'react';
import { View, Text, FlatList, StyleSheet } from 'react-native';
import { useFocusEffect } from '@react-navigation/native';
import { getOrdersByUser } from '../services/orderService';
import { getUser } from '../services/authService';

export default function OrdersScreen() {
  const [orders, setOrders] = useState([]);

  useFocusEffect(
    useCallback(() => {
      loadOrders();
    }, [])
  );

  const loadOrders = async () => {
    try {
      const user = await getUser();
      const res = await getOrdersByUser(user.id);
      setOrders(res.data);
    } catch (e) {
      console.log('Błąd:', e);
    }
  };

  const renderOrder = ({ item }) => (
    <View style={styles.card}>
      <View style={styles.header}>
        <Text style={styles.orderId}>Zamówienie #{item.id}</Text>
        <Text style={styles.total}>{item.totalAmount} PLN</Text>
      </View>
      <Text style={styles.date}>{new Date(item.orderDate).toLocaleDateString('pl-PL')}</Text>
      {item.orderItems?.map((oi) => (
        <Text key={oi.id} style={styles.item}>🎮 {oi.game?.title} x{oi.quantity} — {oi.unitPrice} PLN</Text>
      ))}
    </View>
  );

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Moje zamówienia</Text>
      <FlatList
        data={orders}
        keyExtractor={(item) => item.id.toString()}
        renderItem={renderOrder}
        ListEmptyComponent={<Text style={styles.empty}>Brak zamówień</Text>}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#1a1a2e', paddingTop: 50 },
  title: { fontSize: 28, fontWeight: 'bold', color: '#e94560', paddingHorizontal: 20, marginBottom: 15 },
  card: { backgroundColor: '#16213e', marginHorizontal: 15, marginBottom: 10, padding: 15, borderRadius: 12 },
  header: { flexDirection: 'row', justifyContent: 'space-between' },
  orderId: { color: '#fff', fontWeight: 'bold', fontSize: 16 },
  total: { color: '#e94560', fontWeight: 'bold', fontSize: 16 },
  date: { color: '#888', fontSize: 12, marginTop: 4 },
  item: { color: '#ccc', fontSize: 13, marginTop: 6 },
  empty: { color: '#888', textAlign: 'center', marginTop: 50, fontSize: 16 }
});