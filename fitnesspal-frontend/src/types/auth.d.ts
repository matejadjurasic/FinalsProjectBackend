export interface User {
    id: number;
    username: string;
    email: string;
    name: string;
    height: number;
    weight: number;
    age: number;
    gender: string;
    roles: string[];
    token: string;
}
  
export interface AuthState {
    user: User | null;
    token: string | null;
    loading: boolean;
    error: string | null;
    validationErrors: Record<string, string[]> | null;
    successMessage: string | null;
}
  
export interface LoginCredentials {
    email: string;
    password: string;
}
  
export interface RegisterData extends LoginCredentials {
    username: string;
    confirmPassword: string;
    name: string;
    height: number;
    weight: number;
    age: number;
    gender: string;
}
  
export interface APIError {
    errorMessage: string;
    validationErrors?: Record<string, string[]>;
}