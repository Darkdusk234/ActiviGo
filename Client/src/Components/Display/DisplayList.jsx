import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/css";
import "./DisplayList.css";

export default function DisplayList({ items, renderItem }) {
  return (
    <Swiper
      width="cover"
      spaceBetween={20}
      slidesPerView="auto"
      navigation // Enable
      FreeMode={true}// Enable pagination
      mousewheel={true} // Enable mousewheel control
      className="mySwiper"
      
    >
      {items.map((item) => (
        <SwiperSlide key={item.id}>
          {renderItem(item)}
        </SwiperSlide>
      ))}
    </Swiper>
  );
}
