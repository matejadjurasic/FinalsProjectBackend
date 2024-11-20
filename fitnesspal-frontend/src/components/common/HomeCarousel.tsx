import Carousel from 'react-bootstrap/Carousel';

function HomeCarousel() {
  return (
    <Carousel>
      <Carousel.Item>
        <img
        //className="d-block w-100"
            //style={{ width: '1000px', height: '600px', objectFit: 'cover' }}
            style={{ height: '650px', objectFit: 'cover' }}
          src="/images/5.png" // Path to the first image
          alt="First slide"
        />
        <Carousel.Caption>
          <h3>First slide label</h3>
          <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
            //style={{ width: '300px', height: '200px', objectFit: 'cover' }}
            style={{ height: '650px', objectFit: 'cover' }}
          src="/images/4.png" // Path to the first image
          alt="First slide"
        />
        <Carousel.Caption>
          <h3>Second slide label</h3>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
            //style={{ width: '300px', height: '200px', objectFit: 'cover' }}
            style={{ height: '650px', objectFit: 'cover' }}
          src="/images/3.png" // Path to the first image
          alt="First slide"
        />
        <Carousel.Caption>
          <h3>Third slide label</h3>
          <p>
            Praesent commodo cursus magna, vel scelerisque nisl consectetur.
          </p>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  );
}

export default HomeCarousel;