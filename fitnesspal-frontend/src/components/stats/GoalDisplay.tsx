import React from 'react';
import Button from '../common/Button';
import { useSelector } from 'react-redux';

interface GoalProps {
    onDelete: (id: number) => void;
}

const GoalDisplay: React.FC<GoalProps> = ({ onDelete }) => {

    const goals = useSelector((state: any) => state.goals.goals); 

    return (
        <div className="text-gray-100 text-lg font-semibold">
            <p>Goal: {goals[0].type}</p>
            <p>Target Calories: {goals[0].targetCalories} kcal</p>
            <p>Target Carbs: {Math.round(goals[0].targetCarbs)}g</p>
            <p>Target Fats: {Math.round(goals[0].targetFats)}g</p>
            <p>Target Protein: {Math.round(goals[0].targetProtein)}g</p>
            <p>Target Weight: {Math.round(goals[0].targetWeight)}kg</p>
            <Button onClick={() => onDelete(goals[0].id)} variant='danger'>Delete Goal</Button>
        </div>
    );
};

export default GoalDisplay;