import { View, Text } from 'react-native'
import React from 'react'
import { SafeAreaView } from 'react-native-safe-area-context'
import { ScrollView } from 'react-native-gesture-handler'


export default function App() {
  return (
    <SafeAreaView style= {{backgroundColor: '#000814'}}>
        <ScrollView contentContainerStyle={{height: '100%'}}>
            <View >
                <Text>index</Text>
            </View>
        </ScrollView>
    </SafeAreaView>
  )
}
