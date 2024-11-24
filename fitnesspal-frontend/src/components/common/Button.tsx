import React from 'react';

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: 'primary' | 'secondary' | 'danger';
  isLoading?: boolean;
  attribute?: string; 
}

const buttonStyles = {
  base: 'w-full px-4 py-2 font-semibold rounded-md focus:outline-none focus:ring',
  variants: {
    primary: 'text-white bg-teal-500 hover:bg-teal-700 focus:ring-teal-200',
    secondary: 'text-gray-700 bg-gray-200 hover:bg-gray-300 focus:ring-gray-200',
    danger: 'text-white bg-red-600 hover:bg-red-700 focus:ring-red-200',
  },
  loading: 'opacity-50 cursor-not-allowed',
};

export default function Button({
  variant = 'primary',
  isLoading = false,
  children,
  attribute = '', // Default to an empty string
  ...props
}: ButtonProps) {
  return (
    <button
      className={`${buttonStyles.base} ${buttonStyles.variants[variant]} ${attribute} ${
        isLoading ? buttonStyles.loading : ''
      }`}
      disabled={isLoading || props.disabled}
      aria-busy={isLoading}
      {...props}
    >
      {isLoading ? 'Loading...' : children}
    </button>
  );
}