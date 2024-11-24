import React from 'react';
import { useAuth } from '../../hooks/useAuth';

export default function UserInfo() {

    const{ user } = useAuth();

    return (
        <>
            <h2 className="text-3xl font-bold mb-4">Profile Information</h2>
            <div className="mb-4">
                <p className='text-lg'><strong>Username:</strong> {user?.username}</p>
                <p className='text-lg'><strong>Email:</strong> {user?.email}</p>
                <p className='text-lg'><strong>Name:</strong> {user?.name}</p>
                <p className='text-lg'><strong>Height:</strong> {user?.height} cm</p>
                <p className='text-lg'><strong>Weight:</strong> {user?.weight} kg</p>
                <p className='text-lg'><strong>Age:</strong> {user?.age} years</p>
                <p className='text-lg'><strong>Gender:</strong> {user?.gender}</p>
            </div>
        </>
    );
};