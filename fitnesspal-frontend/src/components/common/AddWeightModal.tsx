import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { createDailyWeight } from '../../store/slices/dailyWeightsSlice';
import { AppDispatch } from '../../store';

interface AddWeightModalProps {
    isOpen: boolean;
    onClose: () => void;
    date: string; // ISO date string
}

const AddWeightModal: React.FC<AddWeightModalProps> = ({ isOpen, onClose, date }) => {
    const [weight, setWeight] = useState<number | ''>('');
    const dispatch = useDispatch<AppDispatch>();

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (weight) {
            const dailyWeightData = {
                dateTime: date,
                weight: weight,
            };
            await dispatch(createDailyWeight(dailyWeightData));
            onClose(); // Close the modal after submission
        }
    };

    if (!isOpen) return null;

    return (
        <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
            <div className="bg-white p-6 rounded shadow-md">
                <h2 className="text-lg font-bold mb-4">Add Your Weight for the Day</h2>
                <form onSubmit={handleSubmit}>
                    <input
                        type="number"
                        value={weight}
                        onChange={(e) => setWeight(Number(e.target.value))}
                        placeholder="Enter weight in kg"
                        className="border rounded p-2 mb-4 w-full"
                        required
                    />
                    <div className="flex justify-end">
                        <button type="button" onClick={onClose} className="mr-2 text-gray-500">Cancel</button>
                        <button type="submit" className="bg-blue-500 text-white rounded px-4 py-2">Add Weight</button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default AddWeightModal;