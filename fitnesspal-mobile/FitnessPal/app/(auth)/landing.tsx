import React, { useState } from 'react';
import { View, Text, TextInput, Button } from 'react-native';
import { Picker } from '@react-native-picker/picker'; 
import apiClient from '../../api/axios';
import  useUserStore  from '../../store/useUserStore';
import { APIError } from '../../constants/types';

interface LandingScreenProps {
    initialWeight: number;
    initialHeight: number;
    initialAge: number;
    initialGender: string;
}

const LandingScreen: React.FC<LandingScreenProps> = ({
    initialWeight,
    initialHeight,
    initialAge,
    initialGender,}) => {
    const { user } = useUserStore();
    const [goal, setGoal] = useState({
        weight: initialWeight,
        height: initialHeight,
        age: initialAge,
        gender: initialGender,
        activityLevel: 'ModeratelyActive',
        type: 'WeightLoss',
        targetWeight: 65,
    });
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<APIError | null>(null);

    const handleSetGoal = async () => {
        setLoading(true);
        setError(null);

        try {
            await apiClient.post('/set-goal', goal); // Adjust the endpoint as needed
            // Handle success (e.g., redirect or show success message)
        } catch (error) {
            const apiError = error as APIError;
            setError(apiError);
        } finally {
            setLoading(false);
        }
    };

    return (
        <View>
            <Text>Welcome, {user?.name}</Text>
            <Text>Activity Level:</Text>
            <Picker
                selectedValue={goal.activityLevel}
                onValueChange={(itemValue: string) => setGoal({ ...goal, activityLevel: itemValue })}>
                <Picker.Item label="Sedentary" value="Sedentary" />
                <Picker.Item label="Lightly Active" value="LightlyActive" />
                <Picker.Item label="Moderately Active" value="ModeratelyActive" />
                <Picker.Item label="Very Active" value="VeryActive" />
                <Picker.Item label="Super Active" value="SuperActive" />
            </Picker>
            <Text>Type:</Text>
            <Picker
                selectedValue={goal.type}
                onValueChange={(itemValue: string) => setGoal({ ...goal, type: itemValue })}>
                <Picker.Item label="Weight Loss" value="WeightLoss" />
                <Picker.Item label="Muscle Gain" value="MuscleGain" />
                <Picker.Item label="Maintenance" value="Maintenance" />
            </Picker>
            <TextInput
                placeholder="Target Weight"
                value={goal.targetWeight.toString()}
                onChangeText={(text) => setGoal({ ...goal, targetWeight: Number(text) })}
                keyboardType="numeric"
            />
            <Button title={loading ? 'Setting Goal...' : 'Set Goal'} onPress={handleSetGoal} disabled={loading} />
            {error && <Text>{error.errorMessage}</Text>}
        </View>
    );
};

export default LandingScreen;