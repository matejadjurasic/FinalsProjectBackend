import { USER_ROLES, GOAL_TYPE, ACTIVITY_LEVEL, GENDER} from "./constants";

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