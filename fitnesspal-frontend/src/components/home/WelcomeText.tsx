import React from 'react'
import { useAuth } from '../../hooks/useAuth';

export default function WelcomeText() {

    const{ user } = useAuth();

    return (
        <h2 className="mb-12 text-3xl font-bold text-gray-100">
            Welcome, {user?.name}!
        </h2>
    )
}
