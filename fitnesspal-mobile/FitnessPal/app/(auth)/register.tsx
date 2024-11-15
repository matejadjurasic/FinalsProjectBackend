import React, { useState } from 'react';
import { View, Text, TextInput, Button } from 'react-native';
import { useRouter } from 'expo-router';
import  useUserStore  from '../../store/useUserStore';

const RegisterScreen = () => {
    const { register, error, loading } = useUserStore();
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const [name, setName] = useState('');
    const [height, setHeight] = useState(0);
    const [weight, setWeight] = useState(0);
    const [age, setAge] = useState(0);
    const [gender, setGender] = useState('Male');
    const router = useRouter();

    const handleRegister = async () => {
        await register(username, password, email, name, height, weight, age, gender);
        // Navigate to Landing screen after successful registration
        router.push({
            pathname: './landing',
            params: { initialWeight: weight, initialHeight: height, initialAge: age, initialGender: gender },
        });
    };

    return (
        <View>
            <Text>Register</Text>
            <TextInput placeholder="Username" value={username} onChangeText={setUsername} />
            <TextInput placeholder="Password" value={password} onChangeText={setPassword} secureTextEntry />
            <TextInput placeholder="Email" value={email} onChangeText={setEmail} keyboardType="email-address" />
            <TextInput placeholder="Name" value={name} onChangeText={setName} />
            <TextInput placeholder="Height" value={height.toString()} onChangeText={(text) => setHeight(Number(text))} keyboardType="numeric" />
            <TextInput placeholder="Weight" value={weight.toString()} onChangeText={(text) => setWeight(Number(text))} keyboardType="numeric" />
            <TextInput placeholder="Age" value={age.toString()} onChangeText={(text) => setAge(Number(text))} keyboardType="numeric" />
            <Button title="Register" onPress={handleRegister} disabled={loading} />
            {error && <Text>{error.errorMessage}</Text>}
        </View>
    );
};

export default RegisterScreen;