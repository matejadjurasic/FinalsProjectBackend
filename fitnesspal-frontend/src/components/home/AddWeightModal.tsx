import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { clearDailyWeightErrors, createDailyWeight } from '../../store/slices/dailyWeightsSlice';
import { AppDispatch } from '../../store';
import Button from '../common/Button';
import ErrorDisplay from '../error/ErrorDisplay';

interface AddWeightModalProps {
    isOpen: boolean;
    onClose: () => void;
    date: string; 
}

const AddWeightModal: React.FC<AddWeightModalProps> = ({ isOpen, onClose, date }) => {
    const [weight, setWeight] = useState<number | ''>('');
    const dispatch = useDispatch<AppDispatch>();
    const errors = useSelector((state: any) => state.dailyWeights.error);
    const validationErrors = useSelector((state: any) => state.dailyWeights.validationError);

    useEffect(() => {
        dispatch(clearDailyWeightErrors());
    }, [dispatch]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (weight) {
            const dailyWeightData = {
                dateTime: date,
                weight: weight,
            };
            await dispatch(createDailyWeight(dailyWeightData)).then((result) => {
                if (createDailyWeight.fulfilled.match(result)) {
                    handleClose();
                }
            }); 
        }
    };

    const handleClose = () => {
        dispatch(clearDailyWeightErrors());
        setWeight('');
        onClose();
    };

    if (!isOpen) return null;

    return (
        <div className="fixed z-40 inset-0 flex items-center justify-center bg-black bg-opacity-50">
            <div className="bg-gray-800 p-6 rounded shadow-md">
                <h2 className="text-lg font-bold mb-4 text-gray-100">Add Your Weight for the Day</h2>
                <ErrorDisplay error={errors} validationErrors={validationErrors} />
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
                        <Button type="button" onClick={handleClose} className="mr-2 text-gray-500">Cancel</Button>
                        <Button type="submit" variant='primary'>Add Weight</Button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default AddWeightModal;