import { DEFAULT_TARGETS } from './constants';
import { DailyWeight, User } from './types';

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

export const createChartData = (dailyWeights: DailyWeight[]) => {
    if (dailyWeights && dailyWeights.length > 0) {
        const lastWeights = dailyWeights.slice(0, 10).reverse();
        const labels = lastWeights.map((weight) => new Date(weight.dateTime).toLocaleDateString());
        const data = lastWeights.map((weight) => weight.weight);
        return {
            labels,
            datasets: [
                {
                    label: 'Daily Weight (kg)',
                    data,
                    borderColor: 'rgba(75, 192, 192, 1)',
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    fill: true,
                },
            ],
        };
    } else {
        return {
            labels: [],
            datasets: [
                {
                    label: 'Daily Weight (kg)',
                    data: [],
                    borderColor: 'rgba(75, 192, 192, 1)',
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    fill: true,
                },
            ],
        };
    }
};

export const calculateProgressPercentage = (current: number, target: number): number => {
    return Math.min((current / target) * 100, 100);
};

export const getFirstLetterOfUser = (user: User | null): string => {
    return user && user.name ? user.name.charAt(0).toUpperCase() : 'U';
};