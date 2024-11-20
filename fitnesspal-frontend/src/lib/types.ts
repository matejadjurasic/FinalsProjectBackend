import { USER_ROLES, GOAL_TYPE, ACTIVITY_LEVEL, GENDER, MEAL_TYPE} from "./constants";

export type User  = {
    id: number;
    username: string;
    email: string;
    name: string;
    height: number;
    weight: number;
    age: number;
    gender: string;
    roles: USER_ROLES[];
    token: string;
}

export type UsersState = {
    users: User[];
    loading: boolean; 
    error: string | null;
    successMessage: string | null; 
    validationErrors: Record<string, string[]> | null; 
};
  
export type AuthState = {
    user: User | null;
    token: string | null;
    loading: boolean;
    error: string | null;
    validationErrors: Record<string, string[]> | null;
    successMessage: string | null;
}
  
export type LoginCredentials = {
    email: string;
    password: string;
}
  
export type RegisterData = {
    email: string;
    password: string;
    username: string;
    confirmPassword: string;
    name: string;
    height: number;
    weight: number;
    age: number;
    gender: GENDER;
}
  
export type APIError = {
    errorMessage: string;
    validationErrors?: Record<string, string[]>;
}

export type Goal = {
    id: number;
    TargetCalories: number;
    TargetProtein: number;
    TargetCarbs: number;
    TargetFats: number;
    TargetWeight: number;
    Type: GOAL_TYPE; 
};

export type GoalsState = {
    goals: Goal[];
    loading: boolean;
    error: string | null;
    successMessage: string | null;
    validationErrors: Record<string, string[]> | null;
};


export type CalculatorGoalData = {
    weight: number;
    height: number;
    age: number;
    gender: string;
    activityLevel: ACTIVITY_LEVEL;
    type: GOAL_TYPE;
    targetWeight: number;
};

export type Meal = {
    id: number;
    calories: number;
    protein: number;
    carbs: number;
    fat: number;
    mealType: MEAL_TYPE; 
    dateTime: string; 
};

export type MealsState = {
    meals: Meal[];
    loading: boolean;
    error: string | null;
    successMessage: string | null;
    validationErrors: Record<string, string[]> | null;
};

export type DailyWeight = {
    id: number;
    dateTime: string; // ISO 8601 format
    weight: number;
};

export type DailyWeightsState = {
    dailyWeights: DailyWeight[];
    loading: boolean;
    error: string | null;
    successMessage: string | null;
    validationErrors: Record<string, string[]> | null;
};

export type MealItem = {
    amount: number; 
    mealId: number; 
    ingredientId: number; 
};

export type MealItemsState = {
    mealItems: MealItem[];
    loading: boolean;
    error: string | null;
    successMessage: string | null;
    validationErrors: Record<string, string[]> | null;
};

export type Ingredient = {
    id: number; 
    name: string; 
    description: string;
    calories: number; 
    protein: number; 
    carbs: number; 
    fat: number; 
};

export type IngredientsState = {
    ingredients: Ingredient[];
    loading: boolean;
    error: string | null;
    successMessage: string | null;
    validationErrors: Record<string, string[]> | null;
};