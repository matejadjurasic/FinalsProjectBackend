import React from 'react';
import Button from '../common/Button';

interface DailyWeightProps {
    message: string;
    onAddWeight: () => void;
}

const DailyWeight: React.FC<DailyWeightProps> = ({ message, onAddWeight }) => {
    return (
        <div className="mt-20 ml-10 w-2/5">
            <h1 className="text-gray-100 text-xxl font-bold">Be responsible</h1>
            <h3 className="text-gray-100 text-xl font-semibold">Add Your Weight for the Day</h3>
            {!message && (
                <Button
                    onClick={onAddWeight}
                    variant='primary'
                    attribute='mt-2 w-80'
                >
                    Add Weight
                </Button>
            )}
            {message && <p className="mt-2 text-green-600 text-l font-semibold">{message}</p>}
        </div>
    );
};

export default DailyWeight;