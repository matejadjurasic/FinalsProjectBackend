export type APIError = {
    errorMessage: string;
    validationErrors?: Record<string, string[]>;
}

export type User = {
    id: number;
    username: string;
    email: string;
    name: string;
    height: number;
    weight: number;
    age: number;
    gender: string;
    token: string;
    roles: string[];
};

export type Goal = {
    id: number; 
    TargetCalories: number;
    TargetProtein: number;
    TargetCarbs: number;
    TargetFats: number;
    TargetWeight: number;
    Type: string;
};

export type DailyWeight = {
    id: number; // Add the id field
    userId: number; // Add the userId field
    DateTime: string; // ISO date string
    Weight: number;
};

export type Meal = {
    id: number; // Add the id field
    userId: number; // Add the userId field
    Calories: number;
    Protein: number;
    Carbs: number;
    Fat: number;
    MealType: string;
    DateTime: string; // ISO date string
};

export type MealItem = {
    amount: number;
    mealId: number; // Reference to the Meal entity
    ingredientId: number; // Reference to the Ingredient entity
};

export type Ingredient = {
    id: number; // Add the id field
    Name: string;
    Description: string;
    Calories: number;
    Protein: number;
    Carbs: number;
    Fat: number;
};