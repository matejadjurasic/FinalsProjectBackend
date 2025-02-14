import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import apiClient from '../../api/axios';
import { DailyWeight, DailyWeightsState, APIError } from '../../lib/types';

const initialState: DailyWeightsState = {
    dailyWeights: [],
    loading: false,
    error: null,
    successMessage: null,
    validationErrors: null,
};

// Fetch all daily weights
export const fetchDailyWeights = createAsyncThunk<DailyWeight[], void, { rejectValue: APIError }>(
    'dailyWeights/fetchDailyWeights',
    async (_, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<DailyWeight[]>('/dailyweights');
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Fetch daily weight by date
export const fetchDailyWeightByDate = createAsyncThunk<DailyWeight[], string, { rejectValue: APIError }>(
    'dailyWeights/fetchDailyWeightByDate',
    async (date, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<DailyWeight[]>(`/dailyweights/date?date=${date}`);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Fetch daily weight by ID
export const fetchDailyWeightById = createAsyncThunk<DailyWeight, number, { rejectValue: APIError }>(
    'dailyWeights/fetchDailyWeightById',
    async (id, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<DailyWeight>(`/dailyweights/${id}`);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Create a new daily weight
export const createDailyWeight = createAsyncThunk<number, Omit<DailyWeight, 'id'>, { rejectValue: APIError }>(
    'dailyWeights/createDailyWeight',
    async (dailyWeightData, { rejectWithValue }) => {
        try {
            const response = await apiClient.post<number>('/dailyweights', dailyWeightData);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Update an existing daily weight
export const updateDailyWeight = createAsyncThunk<{ id: number; dailyWeightData: Partial<DailyWeight> }, { id: number; dailyWeightData: Partial<DailyWeight> }, { rejectValue: APIError }>(
    'dailyWeights/updateDailyWeight',
    async ({ id, dailyWeightData }, { rejectWithValue }) => {
        try {
            await apiClient.put(`/dailyweights/${id}`, dailyWeightData);
            return { id, dailyWeightData };
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Delete a daily weight
export const deleteDailyWeight = createAsyncThunk<number, number, { rejectValue: APIError }>(
    'dailyWeights/deleteDailyWeight',
    async (id, { rejectWithValue }) => {
        try {
            await apiClient.delete(`/dailyweights/${id}`);
            return id;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

const dailyWeightsSlice = createSlice({
    name: 'dailyWeights',
    initialState,
    reducers: {
        clearDailyWeightsState(state) {
            state.dailyWeights = [];
            state.loading = false;
            state.error = null;
            state.successMessage = null;
            state.validationErrors = null;
        },
        clearDailyWeightErrors(state) { 
            state.error = null;
            state.validationErrors = null;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchDailyWeights.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchDailyWeights.fulfilled, (state, action) => {
                state.loading = false;
                state.dailyWeights = action.payload;
            })
            .addCase(fetchDailyWeights.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(fetchDailyWeightByDate.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchDailyWeightByDate.fulfilled, (state, action) => {
                state.loading = false;
                state.dailyWeights = action.payload;
            })
            .addCase(fetchDailyWeightByDate.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(fetchDailyWeightById.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchDailyWeightById.fulfilled, (state, action) => {
                state.loading = false;
                const existingWeight = state.dailyWeights.find(weight => weight.id === action.payload.id);
                if (!existingWeight) {
                    state.dailyWeights.push(action.payload);
                }
            })
            .addCase(fetchDailyWeightById.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(createDailyWeight.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(createDailyWeight.fulfilled, (state, action) => {
                const newDailyWeight: DailyWeight = {
                    id: action.payload,
                    ...action.meta.arg
                };
                state.dailyWeights.push(newDailyWeight);
                state.loading = false;
                state.successMessage = 'Daily weight created successfully!';
            })
            .addCase(createDailyWeight.rejected, (state, action: PayloadAction<APIError | undefined>) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(updateDailyWeight.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(updateDailyWeight.fulfilled, (state, action) => {
                const { id, dailyWeightData } = action.payload;
                const updateWeight = (weights: DailyWeight[]) => {
                    const index = weights.findIndex(weight => weight.id === id);
                    if (index !== -1) {
                        weights[index] = { ...weights[index], ...dailyWeightData };
                    }
                };
                updateWeight(state.dailyWeights);
                state.loading = false;
                state.successMessage = 'Daily weight updated successfully!';
            })
            .addCase(updateDailyWeight.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(deleteDailyWeight.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(deleteDailyWeight.fulfilled, (state, action) => {
                state.dailyWeights = state.dailyWeights.filter(weight => weight.id !== action.payload);
                state.loading = false;
                state.successMessage = 'Daily weight deleted successfully!';
            })
            .addCase(deleteDailyWeight.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            });
    },
});

export const { clearDailyWeightsState, clearDailyWeightErrors } = dailyWeightsSlice.actions;
export default dailyWeightsSlice.reducer;