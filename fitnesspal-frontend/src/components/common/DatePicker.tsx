import React from 'react';

interface DatePickerProps {
    selectedDate: string;
    onDateChange: (date: string) => void;
}

const DatePicker: React.FC<DatePickerProps> = ({ selectedDate, onDateChange }) => {
    return (
        <div className="mb-4">
            <label className="block text-sm font-medium text-gray-100">Select Date:</label>
            <input
                type="date"
                value={selectedDate}
                onChange={(e) => onDateChange(e.target.value)}
                max={new Date().toISOString().split('T')[0]}
                className="mt-1 text-lg font-semibold block w-full border-gray-300 bg-gray-200 rounded-md shadow-sm focus:ring focus:ring-blue-200"
            />
        </div>
    );
};

export default DatePicker;