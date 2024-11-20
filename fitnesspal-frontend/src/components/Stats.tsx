import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchDailyWeights } from '../store/slices/dailyWeightsSlice';
import { Line } from 'react-chartjs-2';
import { DailyWeight } from '../lib/types';
import { AppDispatch } from '../store';
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Filler,
    Tooltip,
    Legend,
} from 'chart.js';
import Navbar from './common/Navbar';
import Button from './common/Button'; // Import Button component
import { Goal } from '../lib/types'; // Import Goal type
import { deleteGoal } from '../store/slices/goalsSlice';

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, Filler, Tooltip, Legend);

const navItems = [
    { label: 'Home', path: '/' },
    { label: 'Log', path: '/log' },
    { label: 'Stats', path: '/stats' },
];

const Stats: React.FC = () => {
    const dispatch = useDispatch<AppDispatch>();
    const dailyWeights = useSelector((state: any) => state.dailyWeights.dailyWeights);
    const goals = useSelector((state: any) => state.goals.goals); // Select goals from state
    const [chartData, setChartData] = useState<any>({
        labels: [],
        datasets: [
            {
                label: 'Daily Weight (kg)',
                data: [],
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                fill: true,
            },
        ],
    });

    useEffect(() => {
        // Fetch daily weights when the component mounts
        dispatch(fetchDailyWeights());
    }, [dispatch]);

    useEffect(() => {
        console.log('Daily Weights:', dailyWeights);
        if (dailyWeights && dailyWeights.length > 0) {
            const lastWeights = dailyWeights.slice(0, 10).reverse();
            const labels = lastWeights.map((weight: DailyWeight) => new Date(weight.dateTime).toLocaleDateString());
            const data = lastWeights.map((weight: DailyWeight) => weight.weight);
            setChartData({
                labels,
                datasets: [
                    {
                        label: 'Daily Weight (kg)',
                        data,
                        borderColor: 'rgba(75, 192, 192, 1)',
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        fill: true,
                    },
                ],
            });
        } else {
            setChartData({
                labels: [],
                datasets: [
                    {
                        label: 'Daily Weight (kg)',
                        data: [],
                        borderColor: 'rgba(75, 192, 192, 1)',
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        fill: true,
                    },
                ],
            });
        }
    }, [dailyWeights]);

    const handleDeleteGoal = (id: number) => {
        dispatch(deleteGoal(id));
    };

    return (
        <div className="flex flex-col h-screen bg-gray-100">
            <Navbar items={navItems} />
            <img src="/images/7.png" alt="Description" className="w-full h-40 object-cover" /> {/* Image above the sections */}
            <div className="flex flex-col md:flex-row flex-grow"> {/* Flex container for the two sections */}
                <div className="w-full md:w-2/3 p-8 bg-gray-800"> {/* Left section for the graph */}
                    <h2 className="text-2xl font-bold text-gray-100 mb-4">Weight Stats for the Last 10 Entries</h2>
                    <Line data={chartData} options={{ responsive: true }} />
                </div>

                <div className="w-full md:w-1/3 p-8 bg-gray-800 overflow-y-auto"> {/* Right section for goals */}
                    <h3 className="text-lg font-semibold text-gray-100">Goals</h3>
                    {goals.length > 0 ? (
                        <div className="text-gray-100">
                            <p>Goal: {goals[0].type}</p>
                            <p>Target Calories: {goals[0].targetCalories} kcal</p>
                            <p>Target Carbs: {Math.round(goals[0].targetCarbs)}g</p>
                            <p>Target Fats: {Math.round(goals[0].targetFats)}g</p>
                            <p>Target Protein: {Math.round(goals[0].targetProtein)}g</p>
                            <p>Target Weight: {Math.round(goals[0].targetWeight)}kg</p> {/* Display the first goal's description */}
                            <Button onClick={() => handleDeleteGoal(goals[0].id)} variant='danger'>Delete Goal</Button>
                        </div>
                    ) : (
                        <div className="text-gray-100">
                            <Button className="mt-2 text-gray-100">Add Custom Goal</Button>
                            <Button className="mt-2 text-gray-100">Calculator Goal</Button>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default Stats;