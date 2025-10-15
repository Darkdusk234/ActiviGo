import { Swiper, SwiperSlide } from "swiper/react";
import "swiper/css";
import "./DisplayList.css";

export default function DisplayList({ items, renderItem }) {
  return (
    <div className="display-list-container">
        <Swiper
        spaceBetween={20}
        slidesPerView="auto"
        observer={true}          // observera DOM ändringar
        observeParents={true}
        loop={true}
        navigation // Enable
        FreeMode={true}// Enable pagination
        mousewheel={true} // Enable mousewheel control
        className="my-swiper"
        style={{ height: "100%" }}
        onResize={() => swiper.update()} 
        
        >
        {items.map((item) => (
            <SwiperSlide key={item.id}>
            {renderItem(item)}
            </SwiperSlide>
        ))}
        </Swiper>
    </div>
  );
}
