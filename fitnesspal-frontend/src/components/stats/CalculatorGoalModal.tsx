import React, { useState } from 'react';
import { CalculatorGoalData } from '../../lib/types';
import Button from '../common/Button';
import { useDispatch, useSelector } from 'react-redux';
import { calculatorGoal, clearGoalsErrors, fetchGoals } from '../../store/slices/goalsSlice';
import { useAuth } from '../../hooks/useAuth';
import { ACTIVITY_LEVEL, GOAL_TYPE } from '../../lib/constants';
import { AppDispatch } from '../../store';
import ErrorDisplay from '../error/ErrorDisplay';

interface CalculatorGoalModalProps {
    isOpen: boolean;
    onClose: () => void;
}

const CalculatorGoalModal: React.FC<CalculatorGoalModalProps> = ({ isOpen, onClose }) => {
    const dispatch = useDispatch<AppDispatch>();
    const { user } = useAuth();
    const errors = useSelector((state: any) => state.goals.error);
    const validationErrors = useSelector((state: any) => state.goals.validationErrors);
    //const loading = useSelector((state: any) => state.goals.loading);
    const initialCalculatorData: CalculatorGoalData = {
        weight: user?.weight || 0,
        height: user?.height || 0,
        age: user?.age || 0,
        gender: user?.gender || 'male',
        activityLevel: ACTIVITY_LEVEL.MODERATE, 
        type: GOAL_TYPE.MAINTENANCE,
        targetWeight: 0,
    };
    const [calculatorData, setCalculatorData] = useState<CalculatorGoalData>(initialCalculatorData);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setCalculatorData((prevState) => ({ ...prevState, [name]: value }));
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        dispatch(calculatorGoal(calculatorData)).then((result) => {
            if (calculatorGoal.fulfilled.match(result)) {
                dispatch(fetchGoals());
                onClose(); 
            }
        });
    };

    const handleClose = () => {
        dispatch(clearGoalsErrors());
        setCalculatorData(initialCalculatorData);
        onClose();
    };

    if (!isOpen) return null;

    return (
        <div className="text-black z-40 fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
            <div className="bg-gray-800 p-6 rounded shadow-md w-96">
                <h2 className="text-lg text-gray-100 font-bold mb-4">Calculate Goal</h2>
                <ErrorDisplay error={errors} validationErrors={validationErrors}/>
                <form onSubmit={handleSubmit}>
                    <h3 className='text-gray-100 text-sm font-semibold'>Activity Level:</h3>
                    <select
                        name="activityLevel"
                        value={calculatorData.activityLevel}
                        onChange={handleChange}
                        className="border rounded p-2 mb-2 w-full"
                        required
                    >
                        {Object.values(ACTIVITY_LEVEL).map((level) => (
                            <option key={level} value={level}>{level}</option>
                        ))}
                    </select>
                    <h3 className='text-gray-100 text-sm font-semibold'>Goal Type:</h3>
                    <select
                        name="type"
                        value={calculatorData.type}
                        onChange={handleChange}
                        className="border rounded p-2 mb-2 w-full"
                        required
                    >
                        {Object.values(GOAL_TYPE).map((goalType) => (
                            <option key={goalType} value={goalType}>{goalType}</option>
                        ))}
                    </select>
                    <h3 className='text-gray-100 text-sm font-semibold'>Target Weight:</h3>
                    <input
                        type="number"
                        name="targetWeight"
                        value={calculatorData.targetWeight}
                        onChange={handleChange}
                        placeholder="Target Weight (kg)"
                        className="border rounded p-2 mb-4 w-full"
                        required
                    />
                    <div className="flex justify-end">
                        <Button type="button" onClick={handleClose} className="mr-2 text-gray-500">Cancel</Button>
                        <Button type="submit" variant='primary'>Calculate Goal</Button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default CalculatorGoalModal;