import React from 'react';

interface ProgressBarProps {
  label: string;
  current: number;
  max: number;
}

const ProgressBar: React.FC<ProgressBarProps> = ({ label, current, max }) => {
  const percentage = Math.min((current / max) * 100, 100); // Ensure percentage does not exceed 100

  return (
    <div className="mb-4">
      <label className="block text-sm font-medium text-gray-100">{label}</label>
      <div className="relative pt-1">
        <div className="flex items-center justify-between">
          <span className="text-xs font-semibold inline-block text-blue-600 text-xs leading-none">
            {current} / {max}
          </span>
        </div>
        <div className="flex h-2 bg-gray-200 rounded">
          <div
            className="bg-blue-600 h-full rounded"
            style={{ width: `${percentage}%` }}
          />
        </div>
      </div>
    </div>
  );
};

export default ProgressBar;