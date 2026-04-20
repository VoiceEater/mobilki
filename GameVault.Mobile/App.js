import { View, StyleSheet, Platform } from 'react-native';
import AppNavigator from './src/navigation/AppNavigator';

export default function App() {
  if (Platform.OS === 'web') {
    return (
      <View style={styles.webWrapper}>
        <View style={styles.phoneFrame}>
          <AppNavigator />
        </View>
      </View>
    );
  }
  return <AppNavigator />;
}

const styles = StyleSheet.create({
  webWrapper: {
    flex: 1,
    backgroundColor: '#000',
    alignItems: 'center',
    justifyContent: 'center',
  },
  phoneFrame: {
    width: 390,
    height: 844,
    borderRadius: 40,
    overflow: 'hidden',
    borderWidth: 3,
    borderColor: '#333',
    backgroundColor: '#1a1a2e',
  },
});