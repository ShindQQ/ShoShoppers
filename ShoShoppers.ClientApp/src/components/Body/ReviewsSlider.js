import { useState } from 'react';
import { MdChevronLeft, MdChevronRight } from 'react-icons/md';

const ReviewsSlider = ({ reviews }) => {
    const [firstIndex, setFirstIndex] = useState(0);
    const [centerIndex, setCenterIndex] = useState(1);
    const [lastIndex, setLasIndex] = useState(2);

    function goToPrevious() {
        const isFirstSlide = firstIndex === 0;
        const newIndex = isFirstSlide ? reviews.length - 1 : firstIndex - 1;
        setLasIndex(centerIndex);
        setCenterIndex(firstIndex);
        setFirstIndex(newIndex);
    }

    function goToNext() {
        const isLastSlide = lastIndex === reviews.length - 1;
        const newIndex = isLastSlide ? 0 : lastIndex + 1;
        setCenterIndex(lastIndex);
        setFirstIndex(centerIndex);
        setLasIndex(newIndex);
    }

    return (
        <div className="w-full flex justify-center align-center items-center my-auto p-2 select-none drop-shadow-xl">
            <div className="text-xl cursor-pointer h-[500px] items-center flex justify-center text-black/50 bg-white rounded-l-3xl shadow-xl hover:bg-gray-200 hover:duration-300 duration-300 w-8 sm:h-[600px]"
                onClick={goToPrevious}>
                <MdChevronLeft size={50} />
            </div>
            <div className="h-fit flex flex-row drop-shadow-xl bg-white">
                <img src={reviews[firstIndex].imageLink} alt="/" loading="lazy" className="h-[500px] w-auto bg-center bg-contain bg-no-repeat shadow-lg m-0 lg:mr-2 sm:h-[600px]" />
                <img src={reviews[centerIndex].imageLink} alt="/" loading="lazy" className="h-[600px] w-auto bg-center bg-contain bg-no-repeat shadow-lg hidden lg:block" />
                <img src={reviews[lastIndex].imageLink} alt="/" loading="lazy" className="h-[600px] w-auto bg-center bg-contain bg-no-repeat shadow-lg ml-2 hidden xl:block" />
            </div>
            <div className="text-xl cursor-pointer h-[500px] items-center flex justify-center text-black/50 bg-white rounded-r-3xl shadow-xl hover:bg-gray-200 hover:duration-300 duration-300 w-8 sm:h-[600px]"
                onClick={goToNext}>
                <MdChevronRight size={50} />
            </div>
        </div>
    );
}

export default ReviewsSlider;
