import { Swiper, SwiperSlide } from "swiper/react";
import { FreeMode, Navigation, Mousewheel } from "swiper/modules"; // Import from swiper/modules
import "swiper/css";
import "swiper/css/free-mode";
import "swiper/css/navigation";
import "./DisplayList.css";

export default function DisplayList({ items, renderItem }) {
  return (
    <div className="display-list-container">
      <Swiper
        modules={[FreeMode, Navigation, Mousewheel]} // Register modules here
        spaceBetween={20}
        slidesPerView="auto"
        observer={true}
        observeParents={true}
        loop={false} // Avoid loop with freeMode to prevent issues
        navigation={{
          nextEl: ".swiper-button-next",
          prevEl: ".swiper-button-prev",
        }}
        freeMode={{ enabled: true, momentum: true }}
        mousewheel={{ forceToAxis: true }}
        touchStartPreventDefault={false}
        className="my-swiper"
        style={{ height: "100%" }}
        onSwiper={(swiper) => swiper.update()}
      >
        {items.map((item) => (
          <SwiperSlide key={item.id} style={{ width: "auto" }}>
            {renderItem(item)}
          </SwiperSlide>
        ))}
        <div className="swiper-button-prev"></div>
        <div className="swiper-button-next"></div>
      </Swiper>
    </div>
  );
}