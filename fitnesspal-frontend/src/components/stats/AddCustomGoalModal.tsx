import React, { useState } from 'react';
import { Goal } from '../../lib/types';
import Button from '../common/Button';
import { useDispatch,useSelector } from 'react-redux';
import { clearGoalsErrors, createGoal, fetchGoals } from '../../store/slices/goalsSlice';
import { GOAL_TYPE } from '../../lib/constants';
import { AppDispatch } from '../../store';
import ErrorDisplay from '../error/ErrorDisplay';
import { initialGoalData } from '../../lib/constants';

interface AddCustomGoalModalProps {
    isOpen: boolean;
    onClose: () => void;
}

const AddCustomGoalModal: React.FC<AddCustomGoalModalProps> = ({ isOpen, onClose }) => {
    const dispatch = useDispatch<AppDispatch>();
    const errors = useSelector((state: any) => state.goals.error);
    const validationErrors = useSelector((state: any) => state.goals.validationErrors);
    const loading = useSelector((state: any) => state.goals.loading);
    const [goalData, setGoalData] = useState<Omit<Goal, 'id'>>(initialGoalData);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setGoalData((prevState) => ({ ...prevState, [name]: value }));
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        dispatch(createGoal(goalData)).then((result) => {
            if (createGoal.fulfilled.match(result)) {
                dispatch(fetchGoals());
                handleClose();
            }
        });
    };

    const handleClose = () => {
        dispatch(clearGoalsErrors());
        setGoalData(initialGoalData);
        onClose();
    };

    if (!isOpen) return null;

    return (
        <div className="text-black z-40 fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
            <div className="bg-gray-800 p-6 rounded shadow-md w-96">
                <h2 className="text-lg text-gray-100 font-bold mb-4">Add Custom Goal</h2>
                <ErrorDisplay error={errors} validationErrors={validationErrors}/>
                <form onSubmit={handleSubmit}>
                    <h3 className='text-gray-100 text-sm font-semibold'>Target Calories:</h3>
                    <input
                        type="number"
                        name="TargetCalories"
                        value={goalData.TargetCalories}
                        onChange={handleChange}
                        placeholder="Target Calories"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Target Protein:</h3>
                    <input
                        type="number"
                        name="TargetProtein"
                        value={goalData.TargetProtein}
                        onChange={handleChange}
                        placeholder="Target Protein (g)"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Target Carbs:</h3>
                    <input
                        type="number"
                        name="TargetCarbs"
                        value={goalData.TargetCarbs}
                        onChange={handleChange}
                        placeholder="Target Carbs (g)"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Target Fats:</h3>
                    <input
                        type="number"
                        name="TargetFats"
                        value={goalData.TargetFats}
                        onChange={handleChange}
                        placeholder="Target Fats (g)"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Target Weight (kg):</h3>
                    <input
                        type="number"
                        name="TargetWeight"
                        value={goalData.TargetWeight}
                        onChange={handleChange}
                        placeholder="Target Weight (kg)"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Goal Type:</h3>
                    <select
                        name="Type"
                        value={goalData.Type}
                        onChange={handleChange}
                        className="border rounded p-2 mb-4 w-full"
                    >
                        {Object.values(GOAL_TYPE).map((goalType) => (
                            <option key={goalType} value={goalType}>{goalType}</option>
                        ))}
                    </select>
                    <div className="flex justify-end">
                        <Button type="button" onClick={handleClose} className="mr-2 text-gray-500">Cancel</Button>
                        <Button type="submit" variant='primary' isLoading={loading}>Add Goal</Button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default AddCustomGoalModal;