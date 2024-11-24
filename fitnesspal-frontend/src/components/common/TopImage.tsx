import React from 'react'

interface TopImageProps {
    imageUrl: string; 
}

const TopImage: React.FC<TopImageProps> = ({imageUrl}) => {
  return (
    <img src={imageUrl} alt="TopImage" className="w-full h-40 object-cover"/> 
  )
}

export default TopImage;