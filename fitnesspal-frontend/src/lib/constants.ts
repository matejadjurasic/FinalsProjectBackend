import { Goal } from "./types";

export enum USER_ROLES {
    ADMIN = 'Admin',
    CLIENT = 'Client',
}

export enum ACTIVITY_LEVEL {
    SEDENTARY = 'Sedentary',
    LIGHT = 'LightlyActive',
    MODERATE = 'ModeratelyActive',
    HEAVY = 'VeryActive',
    EXTRA = 'ExtraActive'
}

export enum GENDER {
    MALE = 'Male',
    FEMALE = 'Female'
}

export enum GOAL_TYPE {
    WEIGHTLOSS = 'Weightloss',
    WEIGHTGAIN = 'WeightGain',
    MAINTENANCE = 'Maintenance',
    MILDWEIGHTLOSS = 'MildWeightLoss',
    MILDWEIGHTGAIN = 'MildWeightGain'
}

export enum MEAL_TYPE {
    BREAKFAST = 'Breakfast',
    LUNCH = 'Lunch',
    DINNER = 'Dinner',
    SNACK = 'Snack',
    OTHER = 'Other'
}

export const NAV_ITEMS = [
    { label: 'Home', path: '/' },
    { label: 'Log', path: '/log' },
    { label: 'Stats', path: '/stats' },
];

export const DEFAULT_TARGETS = {
    targetCalories: 2000,
    targetProtein: 50,
    targetFats: 70,
    targetCarbs: 300,
};

export const initialGoalData: Omit<Goal, 'id'> = {
    TargetCalories: 0,
    TargetProtein: 0,
    TargetCarbs: 0,
    TargetFats: 0,
    TargetWeight: 0,
    Type: GOAL_TYPE.MAINTENANCE,
};