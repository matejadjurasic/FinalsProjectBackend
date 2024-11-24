import React from 'react'

interface SidePictureProps {
    imageUrl: string; 
}

const SidePicture :React.FC<SidePictureProps> = ({imageUrl}) => {
  return (
    <div className="w-full md:w-1/2 bg-gray-800 flex items-center justify-center"> 
        <img src={imageUrl} alt="Profile" className="w-full h-full object-cover"/> 
    </div>
  )
}

export default SidePicture;
