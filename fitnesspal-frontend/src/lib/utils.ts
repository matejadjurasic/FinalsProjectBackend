import { DEFAULT_TARGETS } from './constants';
import { DailyWeight } from './types';

export const getTodaysDate = (): string => {
    return new Date().toISOString().split('T')[0];
};

export const calculateMealTotals = (meals: { calories: number; protein: number; fat: number; carbs: number }[]): { calories: number; protein: number; fat: number; carbs: number } => {
    return meals.reduce((acc, meal) => {
        acc.calories += meal.calories;
        acc.protein += meal.protein;
        acc.fat += meal.fat;
        acc.carbs += meal.carbs;
        return acc;
    }, { calories: 0, protein: 0, fat: 0, carbs: 0 });
};

export const getCurrentGoal = (goals: any[]): any => {
    return goals.length > 0 ? goals[0] : DEFAULT_TARGETS;
};

export const getWeightTrackingMessage = (dailyWeights: DailyWeight[]): string => {
    return dailyWeights.length !== 0 ? 'Good job for keeping track of your weight!' : '';
};