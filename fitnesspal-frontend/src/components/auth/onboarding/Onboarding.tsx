import React from 'react';
import { useAuth } from '../../../hooks/useAuth';
import OnboardingForm from './OnboardingForm';

const Onboarding: React.FC = () => {
    const { successMessage } = useAuth();

  return (
    <div className="flex items-center justify-center min-h-screen"
        style={{
          backgroundImage:'url(/images/loginbg.png)',
          backgroundSize: 'cover',
          backgroundPosition: 'center'
        }}>
      <div className="w-full max-w-md">
        {successMessage && <p className="text-green-500 text-center">{successMessage}</p>}
        <OnboardingForm />
      </div>
    </div>
  );
};

export default Onboarding;