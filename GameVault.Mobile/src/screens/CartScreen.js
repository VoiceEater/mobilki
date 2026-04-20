import React, { useState } from 'react';
import { View, Text, TouchableOpacity, StyleSheet, Alert } from 'react-native';
import { createOrder } from '../services/orderService';
import { getUser } from '../services/authService';

export default function CartScreen({ route, navigation }) {
  const { game } = route.params || {};
  const [quantity, setQuantity] = useState(1);

  const handleOrder = async () => {
    try {
      const user = await getUser();
      await createOrder({
        userId: user.id,
        items: [{ gameId: game.id, quantity, unitPrice: game.price }]
      });
      Alert.alert('Sukces', 'Zamówienie złożone!', [
        { text: 'OK', onPress: () => navigation.navigate('Orders') }
      ]);
    } catch (e) {
      Alert.alert('Błąd', 'Nie udało się złożyć zamówienia');
    }
  };

  if (!game) return <View style={styles.container}><Text style={styles.empty}>Koszyk jest pusty</Text></View>;

  return (
    <View style={styles.container}>
      <Text style={styles.header}>Koszyk</Text>
      <View style={styles.item}>
        <Text style={styles.title}>{game.title}</Text>
        <Text style={styles.price}>{game.price} PLN</Text>
      </View>
      <View style={styles.quantityRow}>
        <TouchableOpacity style={styles.qBtn} onPress={() => setQuantity(Math.max(1, quantity - 1))}>
          <Text style={styles.qText}>-</Text>
        </TouchableOpacity>
        <Text style={styles.qNum}>{quantity}</Text>
        <TouchableOpacity style={styles.qBtn} onPress={() => setQuantity(quantity + 1)}>
          <Text style={styles.qText}>+</Text>
        </TouchableOpacity>
      </View>
      <View style={styles.total}>
        <Text style={styles.totalLabel}>Razem:</Text>
        <Text style={styles.totalPrice}>{(game.price * quantity).toFixed(2)} PLN</Text>
      </View>
      <TouchableOpacity style={styles.orderButton} onPress={handleOrder}>
        <Text style={styles.orderText}>Złóż zamówienie</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#1a1a2e', padding: 20, paddingTop: 50 },
  header: { fontSize: 28, fontWeight: 'bold', color: '#e94560', marginBottom: 20 },
  empty: { color: '#888', textAlign: 'center', marginTop: 50, fontSize: 16 },
  item: { backgroundColor: '#16213e', padding: 15, borderRadius: 12, flexDirection: 'row', justifyContent: 'space-between' },
  title: { color: '#fff', fontSize: 16, fontWeight: 'bold' },
  price: { color: '#e94560', fontSize: 16, fontWeight: 'bold' },
  quantityRow: { flexDirection: 'row', justifyContent: 'center', alignItems: 'center', marginTop: 20, gap: 20 },
  qBtn: { backgroundColor: '#0f3460', width: 40, height: 40, borderRadius: 20, justifyContent: 'center', alignItems: 'center' },
  qText: { color: '#fff', fontSize: 20, fontWeight: 'bold' },
  qNum: { color: '#fff', fontSize: 24, fontWeight: 'bold' },
  total: { flexDirection: 'row', justifyContent: 'space-between', marginTop: 30, paddingTop: 15, borderTopWidth: 1, borderTopColor: '#333' },
  totalLabel: { color: '#aaa', fontSize: 18 },
  totalPrice: { color: '#e94560', fontSize: 22, fontWeight: 'bold' },
  orderButton: { backgroundColor: '#e94560', padding: 15, borderRadius: 10, alignItems: 'center', marginTop: 30 },
  orderText: { color: '#fff', fontSize: 18, fontWeight: 'bold' }
});