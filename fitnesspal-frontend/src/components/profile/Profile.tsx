import React, { useEffect, useState } from 'react';
import { useAuth } from '../../hooks/useAuth';
import Button from '../common/Button';
import UpdateUserModal from './UpdateUserModal';
import { User } from '../../lib/types';
import Navbar from '../common/Navbar';
import { NAV_ITEMS } from '../../lib/constants';
import UserInfo from './UserInfo';
import SidePicture from './SidePicture';

const Profile: React.FC = () => {
    const { user } = useAuth();
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [updatedUser, setUpdatedUser] = useState(user);

    useEffect(() => {
        setUpdatedUser(user);
    }, [user]);

    return (
        <div className="flex flex-col h-screen bg-gray-100">
            <Navbar items={NAV_ITEMS} />
            <div className="flex flex-col md:flex-row flex-grow">
                <SidePicture imageUrl='/images/3.png'/>
                <div className="w-full md:w-1/2 p-8 pt-40 bg-gray-800 text-gray-100">
                    <UserInfo/>
                    <Button onClick={() => setIsModalOpen(true)} variant='primary' attribute='w-80'>
                        Edit User Info
                    </Button>
                    {isModalOpen && (
                        <UpdateUserModal
                            isOpen={isModalOpen}
                            onClose={() => setIsModalOpen(false)}
                            user={updatedUser as User}
                        />
                    )}
                </div>
            </div>
        </div>
    );
};

export default Profile;