import React from 'react';
import ProgressBar from 'react-bootstrap/ProgressBar';
import { useSelector } from 'react-redux';
import { getCurrentGoal, calculateProgressPercentage } from '../../lib/utils';

interface DailyProgressProps {
    totals: { calories: number; protein: number; fat: number; carbs: number };
}

const DailyProgress: React.FC<DailyProgressProps> = ({ totals }) => {
    const goals = useSelector((state: any) => state.goals.goals);
    const goal = getCurrentGoal(goals);

    return (
        <div className="mt-8">
            <h3 className="text-gray-100 text-xxl font-bold">Daily Progress</h3>
            <h4 className='text-gray-100 text-base font-semibold'>Calories: {Math.round(totals.calories)}/{Math.round(goal.targetCalories)}</h4>
            <ProgressBar 
                variant='success' 
                className='mb-7' 
                animated 
                striped 
                label={`${Math.round(calculateProgressPercentage(totals.calories, goal.targetCalories))}%`} 
                now={totals.calories} 
                max={Math.round(goal.targetCalories)} 
            />
            <h4 className='text-gray-100 text-base font-semibold'>Protein: {Math.round(totals.protein)}/{Math.round(goal.targetProtein)}</h4>
            <ProgressBar 
                variant='warning' 
                className='mb-7' 
                animated 
                striped 
                label={`${Math.round(calculateProgressPercentage(totals.protein, goal.targetProtein))}%`} 
                now={totals.protein} 
                max={Math.round(goal.targetProtein)} 
            />
            <h4 className='text-gray-100 text-base font-semibold'>Fat: {Math.round(totals.fat)}/{Math.round(goal.targetFats)}</h4>
            <ProgressBar 
                variant='danger' 
                className='mb-7' 
                animated 
                striped 
                label={`${Math.round(calculateProgressPercentage(totals.fat, goal.targetFats))}%`} 
                now={totals.fat} 
                max={Math.round(goal.targetFats)} 
            />
            <h4 className='text-gray-100 text-base font-semibold'>Carbs: {Math.round(totals.carbs)}/{Math.round(goal.targetCarbs)}</h4>
            <ProgressBar 
                variant='info' 
                className='mb-7' 
                animated 
                striped 
                label={`${Math.round(calculateProgressPercentage(totals.carbs, goal.targetCarbs))}%`} 
                now={totals.carbs} 
                max={Math.round(goal.targetCarbs)} 
            />
        </div>
    );
};

export default DailyProgress;