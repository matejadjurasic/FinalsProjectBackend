import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchDailyWeights } from '../../store/slices/dailyWeightsSlice';
import { Line } from 'react-chartjs-2';
import { AppDispatch } from '../../store';
import { Chart as ChartJS, CategoryScale, LinearScale, PointElement, LineElement, Filler, Tooltip, Legend } from 'chart.js';
import Navbar from '../common/Navbar';
import Button from '../common/Button';
import { deleteGoal } from '../../store/slices/goalsSlice';
import TopImage from '../common/TopImage';
import GoalDisplay from './GoalDisplay';
import { NAV_ITEMS } from '../../lib/constants';
import { createChartData } from '../../lib/utils';
import AddCustomGoalModal from './AddCustomGoalModal';
import CalculatorGoalModal from './CalculatorGoalModal';

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, Filler, Tooltip, Legend);

const Stats: React.FC = () => {
    const dispatch = useDispatch<AppDispatch>();
    const dailyWeights = useSelector((state: any) => state.dailyWeights.dailyWeights);
    const goals = useSelector((state: any) => state.goals.goals);
    const [chartData, setChartData] = useState<any>(createChartData(dailyWeights));
    const [isAddGoalModalOpen, setAddGoalModalOpen] = useState(false); 
    const [isCalculatorGoalModalOpen, setCalculatorGoalModalOpen] = useState(false);

    useEffect(() => {
        dispatch(fetchDailyWeights());
    }, [dispatch]);

    useEffect(() => {
        setChartData(createChartData(dailyWeights));
    }, [dailyWeights]);

    const handleDeleteGoal = (id: number) => {
        dispatch(deleteGoal(id));
    };

    return (
        <div className="flex flex-col h-screen bg-gray-100">
            <Navbar items={NAV_ITEMS} />
            <TopImage imageUrl='/images/3.png'/>
            <div className="flex flex-col md:flex-row flex-grow">
                <div className="w-full md:w-2/3 p-8 bg-gray-800">
                    <h2 className="text-3xl font-bold text-gray-100 mb-4">Weight Stats for the Last 10 Entries</h2>
                    <Line data={chartData} options={{ responsive: true }} />
                </div>

                <div className="w-full md:w-1/3 p-8 bg-gray-800 overflow-y-auto">
                    <h3 className="text-2xl font-bold text-gray-100">Goals</h3>
                    {goals.length > 0 ? (
                        <div className="text-gray-100">
                            <GoalDisplay onDelete={handleDeleteGoal} />
                        </div>
                    ) : (
                        <div className="text-gray-100">
                            <Button variant='primary' attribute='mb-3' onClick={() => setAddGoalModalOpen(true)}>Add Custom Goal</Button>
                            <Button variant='secondary' onClick={() => setCalculatorGoalModalOpen(true)}>Calculator Goal</Button>
                        </div>
                    )}
                </div>
            </div>
            <AddCustomGoalModal isOpen={isAddGoalModalOpen} onClose={() => setAddGoalModalOpen(false)} />
            <CalculatorGoalModal isOpen={isCalculatorGoalModalOpen} onClose={() => setCalculatorGoalModalOpen(false)} />
        </div>
    );
};

export default Stats;