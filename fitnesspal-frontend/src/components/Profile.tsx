import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useAuth } from '../hooks/useAuth';
import { updateUser } from '../store/slices/usersSlice';
import Button from './common/Button';
import UpdateUserModal from './common/UpdateUserModal'; // Import the UpdateUserModal component
import { AppDispatch } from '../store';
import { User } from '../lib/types';
import { updateUser as updateUserInAuth } from '../store/slices/authSlice'; // Import the action
import Navbar from './common/Navbar';

const Profile: React.FC = () => {
    const dispatch = useDispatch<AppDispatch>();
    const { user } = useAuth();
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [updatedUser, setUpdatedUser] = useState(user);

    useEffect(() => {
        setUpdatedUser(user); // Set the updated user state when the user changes
    }, [user]);

    const handleUpdateUser = async (updatedUserData: User) => {
        if (updatedUser) {
            await dispatch(updateUser({ id: user?.id ?? 0, userData: updatedUserData }));
            dispatch(updateUserInAuth(updatedUserData)); // Dispatch the updateUser action to update the auth state
            setIsModalOpen(false); // Close the modal after updating
        }
    };

    const navItems = [
        { label: 'Home', path: '/' },
        { label: 'Log', path: '/log' },
        { label: 'Stats', path: '/stats' },
      ];

    return (
        <div className="flex flex-col h-screen bg-gray-100">
            <Navbar items={navItems} />
        <div className="max-w-xl mx-auto p-8 bg-white rounded shadow-md">
            <h2 className="text-2xl font-bold mb-4">Profile</h2>
            <div className="mb-4">
                <p><strong>Username:</strong> {user?.username}</p>
                <p><strong>Email:</strong> {user?.email}</p>
                <p><strong>Name:</strong> {user?.name}</p>
                <p><strong>Height:</strong> {user?.height} cm</p>
                <p><strong>Weight:</strong> {user?.weight} kg</p>
                <p><strong>Age:</strong> {user?.age} years</p>
                <p><strong>Gender:</strong> {user?.gender}</p>
            </div>
            <Button onClick={() => setIsModalOpen(true)}>Edit User Info</Button>

            {isModalOpen && (
                <UpdateUserModal
                    isOpen={isModalOpen}
                    onClose={() => setIsModalOpen(false)}
                    user={updatedUser as User}
                    onUpdate={handleUpdateUser}
                />
            )}
        </div>
        </div>
    );
};

export default Profile;