import React, { useState, useEffect } from 'react';
import { User } from '../../lib/types';

interface UpdateUserModalProps {
    isOpen: boolean;
    onClose: () => void;
    user: User;
    onUpdate: (updatedUser: User) => void;
}

const UpdateUserModal: React.FC<UpdateUserModalProps> = ({ isOpen, onClose, user, onUpdate }) => {
    const [updatedUser, setUpdatedUser] = useState<User>(user);

    useEffect(() => {
        setUpdatedUser(user);
    }, [user]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;

        setUpdatedUser((prevState) => ({ ...prevState, [name]: value }));
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onUpdate(updatedUser);
         // Call the update function passed from the Profile component
    };

    if (!isOpen || !user) return null;

    return (
        <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
            <div className="bg-white p-6 rounded shadow-md w-96">
                <h2 className="text-lg font-bold mb-4">Update User Info</h2>
                <form onSubmit={handleSubmit}>
                    <input
                        type="text"
                        name="username"
                        value={updatedUser.username}
                        onChange={handleChange}
                        placeholder="Username"
                        className="border rounded p-2 mb-4 w-full"
                        required
                    />
                    <input
                        type="email"
                        name="email"
                        value={updatedUser.email}
                        onChange={handleChange}
                        placeholder="Email"
                        className="border rounded p-2 mb-4 w-full"
                        required
                    />
                    <input
                        type="text"
                        name="name"
                        value={updatedUser.name}
                        onChange={handleChange}
                        placeholder="Name"
                        className="border rounded p-2 mb-4 w-full"
                        required
                    />
                    <input
                        type="number"
                        name="height"
                        value={updatedUser.height}
                        onChange={handleChange}
                        placeholder="Height (cm)"
                        className="border rounded p-2 mb-4 w-full"
                        required
                    />
                    <input
                        type="number"
                        name="weight"
                        value={updatedUser.weight}
                        onChange={handleChange}
                        placeholder="Weight (kg)"
                        className="border rounded p-2 mb-4 w-full"
                        required
                    />
                    <input
                        type="number"
                        name="age"
                        value={updatedUser.age}
                        onChange={handleChange}
                        placeholder="Age"
                        className="border rounded p-2 mb-4 w-full"
                        required
                    />
                    <select
                        name="gender"
                        value={updatedUser.gender}
                        onChange={handleChange}
                        className="border rounded p-2 mb-4 w-full"
                    >
                        <option value="male">Male</option>
                        <option value="female">Female</option>
                        <option value="other">Other</option>
                    </select>
                    <div className="flex justify-end">
                        <button type="button" onClick={onClose} className="mr-2 text-gray-500">Cancel</button>
                        <button type="submit" className="bg-blue-500 text-white rounded px-4 py-2">Update</button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default UpdateUserModal;