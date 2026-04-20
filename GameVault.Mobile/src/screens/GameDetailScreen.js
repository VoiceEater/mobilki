import React, { useState, useEffect } from 'react';
import { View, Text, ScrollView, TouchableOpacity, StyleSheet, Alert, TextInput } from 'react-native';
import { getGameById } from '../services/gameService';
import { getReviewsByGame, createReview } from '../services/reviewService';
import { addToWishlist } from '../services/wishlistService';
import { getUser } from '../services/authService';

export default function GameDetailScreen({ route, navigation }) {
  const { gameId } = route.params;
  const [game, setGame] = useState(null);
  const [reviews, setReviews] = useState([]);
  const [rating, setRating] = useState('');
  const [content, setContent] = useState('');
  const [user, setUser] = useState(null);

  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    try {
      const [gameRes, reviewsRes, userData] = await Promise.all([
        getGameById(gameId),
        getReviewsByGame(gameId),
        getUser()
      ]);
      setGame(gameRes.data);
      setReviews(reviewsRes.data);
      setUser(userData);
    } catch (e) {
      console.log('Błąd:', e);
    }
  };

  const handleAddReview = async () => {
    if (!rating || !content) return Alert.alert('Błąd', 'Wypełnij ocenę i treść');
    try {
      await createReview({ gameId, userId: user.id, rating: parseInt(rating), content });
      setRating('');
      setContent('');
      loadData();
    } catch (e) {
      Alert.alert('Błąd', 'Nie udało się dodać recenzji');
    }
  };

  const handleAddToWishlist = async () => {
    try {
      await addToWishlist({ userId: user.id, gameId });
      Alert.alert('Sukces', 'Dodano do listy życzeń!');
    } catch (e) {
      Alert.alert('Błąd', 'Nie udało się dodać');
    }
  };

  if (!game) return <View style={styles.container}><Text style={styles.loading}>Ładowanie...</Text></View>;

  return (
    <ScrollView style={styles.container}>
      <View style={styles.hero}>
        <Text style={styles.emoji}>🎮</Text>
        <Text style={styles.title}>{game.title}</Text>
        <Text style={styles.publisher}>{game.publisher?.name}</Text>
        <Text style={styles.price}>{game.price === 0 ? 'Free to Play' : `${game.price} PLN`}</Text>
      </View>

      <View style={styles.section}>
        <Text style={styles.sectionTitle}>Opis</Text>
        <Text style={styles.description}>{game.description}</Text>
      </View>

      <View style={styles.section}>
        <Text style={styles.sectionTitle}>Gatunki</Text>
        <View style={styles.tags}>
          {game.gameGenres?.map((gg) => (
            <View key={gg.genreId} style={styles.tag}>
              <Text style={styles.tagText}>{gg.genre?.name}</Text>
            </View>
          ))}
        </View>
      </View>

      <View style={styles.section}>
        <Text style={styles.sectionTitle}>Platformy</Text>
        <View style={styles.tags}>
          {game.gamePlatforms?.map((gp) => (
            <View key={gp.platformId} style={styles.tag}>
              <Text style={styles.tagText}>{gp.platform?.name}</Text>
            </View>
          ))}
        </View>
      </View>

      <View style={styles.buttons}>
        <TouchableOpacity style={styles.buyButton} onPress={() => navigation.navigate('Cart', { game })}>
          <Text style={styles.buyText}>Kup teraz</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.wishButton} onPress={handleAddToWishlist}>
          <Text style={styles.wishText}>♡ Wishlist</Text>
        </TouchableOpacity>
      </View>

      <View style={styles.section}>
        <Text style={styles.sectionTitle}>Recenzje ({reviews.length})</Text>
        {reviews.map((r) => (
          <View key={r.id} style={styles.review}>
            <Text style={styles.reviewUser}>{r.user?.username} - {'⭐'.repeat(r.rating)}</Text>
            <Text style={styles.reviewContent}>{r.content}</Text>
          </View>
        ))}

        {user && (
          <View style={styles.addReview}>
            <Text style={styles.addReviewTitle}>Dodaj recenzję</Text>
            <TextInput style={styles.input} placeholder="Ocena (1-5)" placeholderTextColor="#888" value={rating} onChangeText={setRating} keyboardType="numeric" />
            <TextInput style={styles.input} placeholder="Treść recenzji" placeholderTextColor="#888" value={content} onChangeText={setContent} multiline />
            <TouchableOpacity style={styles.submitButton} onPress={handleAddReview}>
              <Text style={styles.submitText}>Wyślij</Text>
            </TouchableOpacity>
          </View>
        )}
      </View>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#1a1a2e' },
  loading: { color: '#fff', textAlign: 'center', marginTop: 50 },
  hero: { alignItems: 'center', padding: 30, backgroundColor: '#16213e' },
  emoji: { fontSize: 60, marginBottom: 10 },
  title: { fontSize: 28, fontWeight: 'bold', color: '#fff' },
  publisher: { color: '#888', fontSize: 16, marginTop: 5 },
  price: { color: '#e94560', fontSize: 22, fontWeight: 'bold', marginTop: 10 },
  section: { padding: 20 },
  sectionTitle: { fontSize: 18, fontWeight: 'bold', color: '#e94560', marginBottom: 10 },
  description: { color: '#ccc', fontSize: 14, lineHeight: 22 },
  tags: { flexDirection: 'row', flexWrap: 'wrap', gap: 8 },
  tag: { backgroundColor: '#0f3460', paddingHorizontal: 12, paddingVertical: 6, borderRadius: 15 },
  tagText: { color: '#fff', fontSize: 12 },
  buttons: { flexDirection: 'row', paddingHorizontal: 20, gap: 10 },
  buyButton: { flex: 1, backgroundColor: '#e94560', padding: 15, borderRadius: 10, alignItems: 'center' },
  buyText: { color: '#fff', fontSize: 16, fontWeight: 'bold' },
  wishButton: { flex: 1, borderWidth: 1, borderColor: '#e94560', padding: 15, borderRadius: 10, alignItems: 'center' },
  wishText: { color: '#e94560', fontSize: 16, fontWeight: 'bold' },
  review: { backgroundColor: '#16213e', padding: 12, borderRadius: 10, marginBottom: 8 },
  reviewUser: { color: '#e94560', fontWeight: 'bold', marginBottom: 4 },
  reviewContent: { color: '#ccc', fontSize: 13 },
  addReview: { marginTop: 15 },
  addReviewTitle: { color: '#fff', fontSize: 16, fontWeight: 'bold', marginBottom: 10 },
  input: { backgroundColor: '#16213e', color: '#fff', padding: 12, borderRadius: 10, marginBottom: 10, fontSize: 14 },
  submitButton: { backgroundColor: '#e94560', padding: 12, borderRadius: 10, alignItems: 'center' },
  submitText: { color: '#fff', fontWeight: 'bold' }
});