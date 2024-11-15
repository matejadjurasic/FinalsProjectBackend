import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import apiClient from '../../api/axios';
import { Goal, GoalsState, CalculatorGoalData, APIError } from '../../lib/types';

const initialState: GoalsState = {
    goals: [],
    loading: false,
    error: null,
    successMessage: null,
    validationErrors: null,
};


export const fetchGoals = createAsyncThunk<Goal[], void, { rejectValue: APIError }>(
    'goals/fetchGoals',
    async (_, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<Goal[]>('/goals');
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

export const fetchGoalById = createAsyncThunk<Goal, number, { rejectValue: APIError }>(
    'goals/fetchGoalById',
    async (id, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<Goal>(`/goals/${id}`);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

export const createGoal = createAsyncThunk<number, Omit<Goal,'id'>, { rejectValue: APIError }>(
    'goals/createGoal',
    async (goalData, { rejectWithValue }) => {
        try {
            const response = await apiClient.post<number>('/goals', goalData);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

export const updateGoal = createAsyncThunk<{ id: number; goalData: Partial<Goal> }, { id: number; goalData: Partial<Goal> }, { rejectValue: APIError }>(
    'goals/updateGoal',
    async ({ id, goalData }, { rejectWithValue }) => {
        try {
            await apiClient.put(`/goals/${id}`, goalData);
            return {id,goalData};
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

export const deleteGoal = createAsyncThunk<number, number, { rejectValue: APIError }>(
    'goals/deleteGoal',
    async (id, { rejectWithValue }) => {
        try {
            await apiClient.delete(`/goals/${id}`);
            return id;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

export const calculatorGoal = createAsyncThunk<number, CalculatorGoalData, { rejectValue: APIError }>(
    'goals/calculatorGoal',
    async (calculatorData, { rejectWithValue }) => {
        try {
            const response = await apiClient.post('/goals/initial', calculatorData);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);


const goalsSlice = createSlice({
    name: 'goals',  
    initialState,
    reducers: {
        clearGoalsState(state) {
            state.goals = [];
            state.loading = false;
            state.error = null;
            state.successMessage = null;
            state.validationErrors = null;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchGoals.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchGoals.fulfilled, (state, action) => {
                state.loading = false;
                state.goals = action.payload;
            })
            .addCase(fetchGoals.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(fetchGoalById.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchGoalById.fulfilled, (state, action) => {
                state.loading = false;
                const existingGoal = state.goals.find(goal => goal.id === action.payload.id);
                if (!existingGoal) {
                    state.goals.push(action.payload);
                }
            })
            .addCase(fetchGoalById.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(createGoal.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(createGoal.fulfilled, (state, action) => {
                const newGoal: Goal = {
                    id: action.payload,
                    ...action.meta.arg
                }
                state.goals.push(newGoal);
                state.loading = false;
                state.successMessage = 'Goal created successfully!';
            })
            .addCase(createGoal.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(updateGoal.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(updateGoal.fulfilled, (state, action) => {
                const { id, goalData } = action.payload;
                const updateGoal = (goals: Goal[]) => {
                    const index = goals.findIndex(goal => goal.id === id);
                    if (index !== -1) {
                        goals[index] = { ...goals[index], ...goalData };
                    }
                };
                updateGoal(state.goals);
                state.loading = false;
                state.successMessage = 'Goal updated successfully!';
            })
            .addCase(updateGoal.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(deleteGoal.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(deleteGoal.fulfilled, (state,action) => {
                state.goals = state.goals.filter(goal => goal.id !== action.payload);
                state.loading = false;
                state.successMessage = 'Goal deleted successfully!';
            })
            .addCase(deleteGoal.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(calculatorGoal.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(calculatorGoal.fulfilled, (state) => {
                state.loading = false;
                state.successMessage = 'Goal calculated successfully!';
            })
            .addCase(calculatorGoal.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
                state.successMessage = null;
            });
    },
});

export const { clearGoalsState } = goalsSlice.actions;
export default goalsSlice.reducer;