import Carousel from 'react-bootstrap/Carousel';

function HomeCarousel() {
  return (
    <Carousel>
      <Carousel.Item>
        <img
          style={{ height: '650px', objectFit: 'cover' }}
          src="/images/9.png" 
          alt="First slide"
        />
        <Carousel.Caption>
          <h3 className='font-bold'>Make every meal count towards your health goals!</h3>
          <p>Embrace a healthy lifestyle and nourish your body with wholesome foods.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          style={{ height: '650px', objectFit: 'cover' }}
          src="/images/8.png" 
          alt="First slide"
        />
        <Carousel.Caption>
          <h3 className='font-bold'>Take care of your body. It's the only place you have to live</h3>
          <p>Tracking your meals is a step towards a healthier you.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          style={{ height: '650px', objectFit: 'cover' }}
          src="/images/3.png"
          alt="First slide"
        />
        <Carousel.Caption>
          <h3 className='font-bold'>You are what you eat, so don't be fast, cheap, easy, or fake.</h3>
          <p>Healthy eating is a way of life, so it's important to establish routines that are simple, realistically, and ultimately enjoyable.</p>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  );
}

export default HomeCarousel;