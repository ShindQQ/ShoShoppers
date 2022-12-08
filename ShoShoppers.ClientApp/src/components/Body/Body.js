import Reviews from './Reviews';

export const Body = () => {
    return (
        <>
            <div className="relative bg-[url('https://ik.imagekit.io/ShoShopers/Home_page_images/shoppers.jpg?ik-sdk-version=javascript-1.4.3&updatedAt=1667491152992')] sm:bg-[url('https://ik.imagekit.io/ShoShopers/Home_page_images/tr:w-4000/%D0%B3%D0%BE%D0%BB%D0%BE%D0%B2%D0%BD%D0%B01_oulv3YAX_.jpg?ik-sdk-version=javascript-1.4.3&updatedAt=1668175913697')] bg-cover bg-center h-screen w-full flex justify-center w-full">
                <div className="flex justify-center flex-col items-center text-center text-3xl sm:text-4xl space-y-8 sm:space-y-16 mx-4 pb-32 font-semibold select-none sm:text-black sm:w-[600px] book-aniqua outline_text">
                    <p>Маєш власний ескіз?</p>
                    <p>Пиши нам в дірект:</p>
                    <p>Завантажуй фото в форматі<span className="inline-block">JPG, PNG, PDF</span></p>
                    <p>Обговорюй всі деталі та отримуй свій шопер за 2-3 дні</p>
                </div>
                <a href="http://instagram.com/_u/sho_shoper_/" className="text-center flex justify-center items-center absolute bottom-20 bg-[#3ba144] w-72 h-16 sm:w-96 rounded-full shadow-xl hover:bg-green-700 hover:ease-in hover:duration-300 duration-300" target="_blank" rel="noopener noreferrer">
                    <p className="text-white text-xl sm:text-2xl font-bold select-none">Створи свій шопер тут!</p>
                </a>
            </div>
            <div className="bg-[#3ba144] h-auto w-full flex flex-col justify-center align-center items-center">
                <p className="text-3xl xl:text-4xl text-white font-bold text-center select-none p-2 mt-4 mb-2">
                    До замовлення доступні такі кольори шоперів:
                </p>
                <div className="w-full h-auto flex justify-evenly items-center mt-4 mb-12 drop-shadow-lg">
                    <div className="flex-col w-44 h-52 sm:w-64 sm:h-72 rounded-t-full flex justify-center">
                        <img loading="lazy" className="w-96 h-52 object-fill object-center inline drop-shadow-xl select-none rounded-t-full" src={"https://ik.imagekit.io/ShoShopers/Home_page_images/photo_2022-10-22_13-49-26_BHfNYGFMhv.jpg?ik-sdk-version=javascript-1.4.3&updatedAt=1666435819183"} alt="/" />
                        <div className="bg-[#038C25] w-full flex-col text-center flex items-center justify-center font-semibold text-lg sm:text-2xl text-white shadow-lg select-none py-1 drop-shadow-lg">
                            <p>Білий</p>
                            <p>Розмір: 40*37см</p>
                            <p>Тканина: 100% бязь</p>
                        </div>
                    </div>
                    <div className="flex-col w-44 h-52 sm:w-64 sm:h-72 rounded-t-full flex justify-center">
                        <img loading="lazy" className="w-96 h-52 object-fill object-center inline drop-shadow-xl select-none rounded-t-full" src={"https://ik.imagekit.io/ShoShopers/Home_page_images/photo_2022-10-22_13-49-26__2__oWPn_SQnG.jpg?ik-sdk-version=javascript-1.4.3&updatedAt=1666435819339"} alt="/" />
                        <div className="bg-[#038C25] w-full flex-col text-center flex items-center justify-center font-semibold text-lg sm:text-2xl text-white shadow-lg select-none py-1 drop-shadow-lg">
                            <p>Чорний</p>
                            <p>Розмір: 40*35см</p>
                            <p>Тканина: 100% бязь</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className="h-80 lg:h-[25rem] w-full flex justify-evenly align-center">
                <div className="h-full w-96 bg-white flex flex-col items-center justify-center">
                    <div className="flex flex-col items-center text-center text-xl sm:text-2xl p-4 space-y-2 mt-2 select-none">
                        <p className="font-bold text-3xl">Доставка</p>
                        <p>Доставка по Україні «Новою» чи «Укрпоштою»</p>
                        <p>Оплата на картку або накладний платіж (при пeредоплаті 50%)</p>
                    </div>
                    <a href="/individual" className="flex justify-center items-center w-48 h-16 bg-[#038C25] text-white text-2xl rounded-full mt-2 shadow-lg font-medium hover:bg-green-700 hover:ease-in hover:duration-300 duration-300">
                        <p>Замовити</p>
                    </a>
                </div>
                <div className="h-[23rem] w-96 hidden md:flex">
                    <div className="h-full w-full bg-[url('https://ik.imagekit.io/ShoShopers/Home_page_images/photo_2022-10-22_14-12-51_09HphfGiZ.jpg?ik-sdk-version=javascript-1.4.3&updatedAt=1666437192121')] rounded-b-full  bg-cover bg-center drop-shadow-xl">
                    </div>
                </div>
            </div>
            <Reviews />
        </>
    );
}
