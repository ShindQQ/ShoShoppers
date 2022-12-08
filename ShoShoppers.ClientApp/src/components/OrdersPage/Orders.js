import React, { useState, useRef, useEffect } from 'react';
import { CartState } from '../../context/Context';
import { RenderCartItems }  from '../Cart/RenderCartItems';
import { RenderCartResult } from '../Cart/RenderCartResult';
import { SetItems, checkItemsAmmount } from '../Cart/itemsAmmountCheck';
import { useOnClickOutside } from '../ClickOutside/useOnClickOutside';
import { InputWithValidation } from './InputWithValidation';
import { NpOption } from './NpOption';
import { totalProductionQuantity } from '../Cart/Cart';
import Swal from 'sweetalert2';

export const Orders = () => {
    const {
        state: { cart },
        dispatch
    } = CartState();

    const [shoppersAndPins, setShoppersAndPins] = useState([]);

    const [items, setItems] = useState([]);
    const [regionsAreLoading, setRegionsAreLoading] = useState(false);
    const [cititesAreLoading, setCitiesAreLoading] = useState(false);
    const [streetsAreLoading, setStreetsAreLoading] = useState(false);
    const [postOfficiesAreLoading, setPostOfficiesAreLoading] = useState(false);

    const [selectedRegion, setSelectedRegion] = useState({ description: '', ref: '' });
    const [selectedCity, setSelectedCity] = useState({ description: '', ref: '' });
    const [selectedStreet, setSelectedStreet] = useState({ description: '', ref: '' });
    const [selectedPostOffice, setSelectedPostOffice] = useState({ description: '', ref: '' });

    const [showRegions, setShowRegions] = useState(false);
    const refRegions = useRef();
    useOnClickOutside(refRegions, () => setShowRegions(false));
    const [showCities, setShowCities] = useState(false);
    const refCities = useRef();
    useOnClickOutside(refCities, () => setShowCities(false));
    const [showStreets, setShowStreets] = useState(false);
    const refStreets = useRef();
    useOnClickOutside(refStreets, () => setShowStreets(false));
    const [showPostOfficies, setShowPostOfficies] = useState(false);
    const refPostOfficies = useRef();
    useOnClickOutside(refPostOfficies, () => setShowPostOfficies(false));

    const [showPhoneValidation, setShowPhoneValidation] = useState(true);
    const [showEmailValidation, setShowEmailValidation] = useState(true);
    const [showNameValidation, setShowNameValidation] = useState(true);
    const [showSurnameValidation, setShowSurnameValidation] = useState(true);
    const [showHouseValidation, setShowHouseValidation] = useState(true);
    const [itemsAmmountCheck, setItemsAmmountCheck] = useState(false);

    const surname = useRef();
    const name = useRef();
    const phone = useRef();
    const email = useRef();
    const [house, setHouse] = useState("");
    const [appartment, setAppartment] = useState("");

    const [selectPostOfficeHouse, setSelectPostOfficeHouse] = useState(false);
    const [selectPostOffice, setSelectPostOffice] = useState(false);
    const [selectCourier, setSelectCourier] = useState(false);

    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        SetItems(setShoppersAndPins);
    }, []);

    function validateInputs() {
        var phoneRegex = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
        var emailRegex = /^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$/;
        var nameAndSurnameRegex = /^[а-яі'`А-ЯІ\-@]+$/;

        const phoneCheck = phoneRegex.test(phone.current.value.trim());
        const emailCheck = emailRegex.test(email.current.value.trim());
        const nameCheck = nameAndSurnameRegex.test(name.current.value.trim());
        const surnameCheck = nameAndSurnameRegex.test(surname.current.value.trim());

        setShowPhoneValidation(phoneCheck);
        setShowEmailValidation(emailCheck);
        setShowNameValidation(nameCheck);
        setShowSurnameValidation(surnameCheck);
        setShowHouseValidation(() => { return house.length > 0 });

        let checkForValidation = phoneCheck && emailCheck && nameCheck && surnameCheck;

        if (!checkForValidation) {
            Swal.fire({
                icon: "error",
                title: "Перевірте введену контактну інформацію!",
                showConfirmButton: false,
                timer: 2500
            });
        }

        if (!selectCourier && !selectPostOfficeHouse && !selectPostOffice) {
            Swal.fire({
                icon: "error",
                title: "Оберіть службу доставки!",
                showConfirmButton: false,
                timer: 2500
            });

            checkForValidation = false;
        }

        if (selectCourier && house.length <= 0) {
            Swal.fire({
                icon: "error",
                title: "Перевірте введений номер будинку!",
                showConfirmButton: false,
                timer: 2500
            });

            checkForValidation = false;
        }

        if (selectCourier && (selectedRegion.description.length <= 0
            || selectedCity.description.length <= 0 || selectedStreet.description.length <= 0)
            || selectPostOffice && (selectedRegion.description.length <= 0
                || selectedCity.description.length <= 0 || selectedPostOffice.description.length <= 0)
            || selectPostOfficeHouse && (selectedRegion.description.length <= 0
                || selectedCity.description.length <= 0 || selectedPostOffice.description.length <= 0)) {
            Swal.fire({
                icon: "error",
                title: "Ви не заповнили службу доставки!",
                showConfirmButton: false,
                timer: 2500
            });

            checkForValidation = false;
        }

        return checkForValidation;
    }

    function validateCart() {
        let check = false;
        check = cart.some(item => {
            const cartCheck = checkItemsAmmount(shoppersAndPins, item);
            if (cartCheck) {

                Swal.fire({
                    icon: "warning",
                    title: "Перевірте кошик!",
                    text: "У вас є товар який закінчився!",
                    showConfirmButton: false,
                    timer: 2500
                });

                return true;
            }
        })

        setItemsAmmountCheck(check);
        return check;
    }

    function setDefaultForNpItems() {
        setItems([]);
        setSelectedRegion({ description: '', ref: '' });
        setSelectedCity({ description: '', ref: '' });
        setSelectedStreet({ description: '', ref: '' });
        setSelectedPostOffice({ description: '', ref: '' });
    }

    function setSelect(selectPostOfficeHouseOption, selectPostOfficeOption, selectCourierOption) {
        setSelectPostOfficeHouse(selectPostOfficeHouseOption);
        setSelectPostOffice(selectPostOfficeOption);
        setSelectCourier(selectCourierOption);
    }

    async function updateOrderByUserToken() {
        setIsLoading(true);

        await fetch('/api/Order/CreateOrderByUserToken', {
            method: 'Put',
            headers: new Headers({
                'Content-Type': 'application/json'
            }),
            body: JSON.stringify({
                'dateOfOrder': new Date(new Date().toString().split('GMT')[0] + ' UTC').toISOString(),
                'dateToFinishOrderAndDiliver': new Date(new Date(new Date().setDate(new Date().getDate() + Math.round(1.5 * totalProductionQuantity(cart)))).toString().split('GMT')[0] + ' UTC').toISOString(),
                'userItems': cart.map(item => { return { 'Ammount': item.qty, 'Name': item.name, 'id': item.id } }),
                'userEmail': email.current.value,
                'userName': name.current.value,
                'userSurname': surname.current.value,
                'postOffice': `${selectedRegion.description} ${selectedCity.description} ${selectedPostOffice.description} 
                                ${selectedStreet.description} ${house} ${appartment}`,
                'userPhoneNumber': phone.current.value,
                'isOrderDone': false,
                'orderPrice': cart.reduce(function (sum, current) { return sum + Number(current.price * current.qty); }, 0),
                'userUniqueToken': localStorage.getItem("UserToken"),
            })
        }).then(response => {
            if (response.status === 200) {
                Swal.fire({
                    icon: "success",
                    title: "Дякуємо за замовлення!",
                    text: "Реквізити для оплати на пошті!",
                    showConfirmButton: false,
                    timer: 4500
                });
                localStorage.removeItem("cart");
                localStorage.removeItem("tokenExpirationTime");
                localStorage.removeItem("UserToken");
                dispatch({
                    type: "REMOVE_CART"
                });
            } else if (response.status === 402) {
                Swal.fire({
                    icon: "warning",
                    title: "Перейдіть до оплати!",
                    showConfirmButton: false,
                    timer: 2500
                });
            } else if (response.status === 400) {
                Swal.fire({
                    icon: "warning",
                    title: "У Вас відсутній токен для замовлення!",
                    text: "Для отримання додайте щось в кошик!",
                    showConfirmButton: false,
                    timer: 2500
                });
            } else {
                Swal.fire({
                    icon: "error",
                    title: "Перевірте введенні данні!",
                    showConfirmButton: false,
                    timer: 2500
                });
            }
        });

        setIsLoading(false);
    }

    return (
        <div className={`w-full h-auto mt-12 mb-12 space-y-8 lg:space-y-0 ${cart.length > 0 ? 'grid grid-cols-1 lg:grid-cols-2' : 'flex justify-center items-center'}`}>
            {isLoading &&
                <div className="bg-black bg-opacity-40 w-full h-full z-50 top-0 fixed flex justify-center items-center">
                    <svg className="h-10 w-10 animate-spin text-white z-50" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                        <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                        <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                    </svg>
                </div>
            }
            <div className={`h-fit flex justify-center rounded-xl ${cart.length > 0 ? 'w-auto' : 'w-2/3'}`}>
                {cart.length > 0 ? (
                    <div className="w-11/12 sm:w-[500px] lg:w-11/12 xl:w-5/6 h-auto flex items-center flex-col shadow-lg rounded-xl">
                        <div className={`${itemsAmmountCheck ? "bg-red-500" : "bg-[#3ba144]"} h-16 w-full text-center flex justify-center items-center rounded-t-xl`}>
                            <p className="text-white text-2xl font-semibold">Корзина</p>
                        </div>
                        <div className="w-full h-fit pt-2">
                            <RenderCartItems style={"flex px-4 flex-col items-center content-center font-medium relative h-[399px] scrollbar overflow-scroll bg-white w-full border-b-[4px] border-gray-200"} orderOption={true} itemsCheck={itemsAmmountCheck} setCheck={setItemsAmmountCheck} />
                        </div>
                        <RenderCartResult style={"text-black text-xl font-medium m-2 flex flex-col space-y-2 mt-4 w-full px-6"} showButton={false} />
                    </div>
                ) : (
                    <div className="w-[360px] sm:w-[500px] lg:w-11/12 xl:w-5/6 h-fit flex items-center flex-col shadow-lg rounded-xl space-y-5 pb-2">
                        <div className="bg-[#3ba144] h-16 w-full text-center flex justify-center items-center rounded-t-xl">
                            <p className="text-white text-2xl font-semibold">Корзина</p>
                        </div>
                        <div className="space-y-3 mt-4 w-full px-4 text-2xl pb-3">
                            <div className="w-full flex justify-center items-center font-semibold">
                                <p>Ваша корзина порожня, замовте зі списку нижче:</p>
                            </div>
                            <div className="w-full flex justify-center items-center">
                                <p>Термін виготовлення індивідуального заказу 2-3 дні</p>
                            </div>
                            <div className="w-full flex justify-center items-center">
                                <button className="w-72 h-12 bg-[#3ba144] hover:bg-green-700 hover:ease-in hover:duration-300 duration-300 rounded-xl shadow-md">
                                    <a href="/individual" className="text-white">
                                        <p>Індивідуальний дизайн</p>
                                    </a>
                                </button>
                            </div>
                            <div className="w-full flex justify-center items-center">
                                <p>Шопери та піни йдуть без терміну виготовлення</p>
                            </div>
                            <div className="w-full flex justify-center items-center">
                                <button className="w-40 h-12 bg-[#3ba144] hover:bg-green-700 hover:ease-in hover:duration-300 duration-300 rounded-xl shadow-md">
                                    <a href="/shoppers" className="text-white">
                                        <p>В наявності</p>
                                    </a>
                                </button>
                            </div>
                            <div className="w-full flex justify-center items-center">
                                <button className="w-24 h-12 bg-[#3ba144] hover:bg-green-700 hover:ease-in hover:duration-300 duration-300 rounded-xl shadow-md">
                                    <a href="/pins" className="text-white">
                                        <p>Піни</p>
                                    </a>
                                </button>
                            </div>
                        </div>
                    </div>
                )}
            </div>
            {cart.length > 0 &&
                <div className="h-auto space-y-8">
                    <div className="w-full items-center flex justify-center">
                        <div className="w-11/12 sm:w-[500px] lg:w-11/12 xl:w-5/6 h-[310px] flex items-center flex-col shadow-lg rounded-xl">
                            <div className="bg-[#3ba144] h-16 w-full text-center flex justify-center items-center rounded-t-xl">
                                <p className="text-white text-2xl font-semibold">Контактна інформація</p>
                            </div>
                            <div className="space-y-3 mt-4 w-full px-4 text-2xl">
                                <InputWithValidation textOption={"Прізвище:"} placeholder="Введіть прізвище" inputValue={surname} showValidation={showSurnameValidation} />
                                <InputWithValidation textOption={"Ім'я:"} placeholder="Введіть ім'я" inputValue={name} showValidation={showNameValidation} />
                                <InputWithValidation textOption={"Email:"} placeholder="Введіть електронну пошту" inputValue={email} showValidation={showEmailValidation} />
                                <InputWithValidation textOption={"Телефон:"} placeholder="0674421792" inputType={"phone"} inputValue={phone} showValidation={showPhoneValidation} />
                            </div>
                        </div>
                    </div>
                    <div className="w-full items-center flex justify-center">
                        <div className="w-11/12 sm:w-[500px] lg:w-11/12 xl:w-5/6 h-auto flex items-center flex-col shadow-lg rounded-xl space-y-3 pb-4">
                            <div className="bg-[#3ba144] h-16 w-full text-center flex justify-center items-center rounded-t-xl mb-2">
                                <p className="text-white text-2xl font-semibold">Служба доставки</p>
                            </div>
                            <div className="w-full flex flex-col space-y-1">
                                <div className="w-full flex justify-start items-center space-x-2 px-4 text-2xl">
                                    <input type="radio" className="cursor-pointer" onClick={() => { setSelect(!selectPostOfficeHouse, false, false); setDefaultForNpItems() }} checked={selectPostOfficeHouse} readOnly />
                                    <p className="text-center">Нова Пошта. Відділення</p>
                                </div>
                                {selectPostOfficeHouse && (
                                    <div className="px-10 space-y-2">
                                        <NpOption url={`/api/np`} setItems={setItems} items={items} setItemsAreLoading={setRegionsAreLoading} divRef={refRegions} placeholder={"Оберіть область"}
                                            setShowItems={setShowRegions} showItems={showRegions} itemsAreLoading={regionsAreLoading} selectedItem={selectedRegion} setSelectedItem={setSelectedRegion} region={true} setCity={setSelectedCity} setPostOffice={setSelectedPostOffice} />
                                        {selectedRegion.ref.length > 0 && (
                                            <NpOption url={`/api/np/getCitiesByRegion`} setItems={setItems} items={items} setItemsAreLoading={setCitiesAreLoading} regionRef={selectedRegion.ref} divRef={refCities} placeholder={"Оберіть місто"}
                                                setShowItems={setShowCities} showItems={showCities} itemsAreLoading={cititesAreLoading} selectedItem={selectedCity} setSelectedItem={setSelectedCity} />
                                        )}
                                        {selectedCity.ref.length > 0 && selectedRegion.ref.length > 0 && (
                                            <NpOption url={`/api/np/getPostOffices`} setItems={setItems} items={items} setItemsAreLoading={setPostOfficiesAreLoading} cityRef={selectedCity.ref} typeOfWarehouseRef={`841339c7-591a-42e2-8233-7a0a00f0ed6f`}
                                                divRef={refPostOfficies} placeholder={"Оберіть відділення"} setShowItems={setShowPostOfficies} showItems={showPostOfficies} itemsAreLoading={postOfficiesAreLoading} selectedItem={selectedPostOffice} setSelectedItem={setSelectedPostOffice} />
                                        )}
                                    </div>
                                )}
                            </div>
                            <div className="w-full flex flex-col space-y-1">
                                <div className="w-full flex justify-start items-center space-x-2 px-4 text-2xl">
                                    <input type="radio" className="cursor-pointer" onClick={() => { setSelect(false, !selectPostOffice, false); setDefaultForNpItems() }} checked={selectPostOffice} readOnly />
                                    <p className="text-center">Нова Пошта. Поштомат</p>
                                </div>
                                {selectPostOffice && (
                                    <div className="px-10 space-y-2">
                                        <NpOption url={`/api/np`} setItems={setItems} items={items} setItemsAreLoading={setRegionsAreLoading} divRef={refRegions} placeholder={"Оберіть область"}
                                            setShowItems={setShowRegions} showItems={showRegions} itemsAreLoading={regionsAreLoading} selectedItem={selectedRegion} setSelectedItem={setSelectedRegion} region={true} setCity={setSelectedCity} setPostOffice={setSelectedPostOffice} />
                                        {selectedRegion.ref.length > 0 && (
                                            <NpOption url={`/api/np/getCitiesByRegion`} setItems={setItems} items={items} setItemsAreLoading={setCitiesAreLoading} regionRef={selectedRegion.ref} divRef={refCities} placeholder={"Оберіть місто"}
                                                setShowItems={setShowCities} showItems={showCities} itemsAreLoading={cititesAreLoading} selectedItem={selectedCity} setSelectedItem={setSelectedCity} />
                                        )}
                                        {selectedCity.ref.length > 0 && selectedRegion.ref.length > 0 && (
                                            <NpOption url={`/api/np/getPostOffices`} setItems={setItems} items={items} setItemsAreLoading={setPostOfficiesAreLoading} cityRef={selectedCity.ref} typeOfWarehouseRef={`f9316480-5f2d-425d-bc2c-ac7cd29decf0`}
                                                divRef={refPostOfficies} placeholder={"Оберіть поштомат"} setShowItems={setShowPostOfficies} showItems={showPostOfficies} itemsAreLoading={postOfficiesAreLoading} selectedItem={selectedPostOffice} setSelectedItem={setSelectedPostOffice} />
                                        )}
                                    </div>
                                )}
                            </div>
                            <div className="w-full flex flex-col space-y-1">
                                <div className="w-full flex justify-start items-center space-x-2 px-4 text-2xl">
                                    <input type="radio" className="cursor-pointer" onClick={() => { setSelect(false, false, !selectCourier); setDefaultForNpItems() }} checked={selectCourier} readOnly />
                                    <p className="text-center">Нова Пошта. Кур'єр</p>
                                </div>
                                {selectCourier && (
                                    <div className="px-10 space-y-2">
                                        <NpOption url={`/api/np`} setItems={setItems} items={items} setItemsAreLoading={setRegionsAreLoading} divRef={refRegions} placeholder={"Оберіть область"}
                                            setShowItems={setShowRegions} showItems={showRegions} itemsAreLoading={regionsAreLoading} selectedItem={selectedRegion} setSelectedItem={setSelectedRegion} region={true} setCity={setSelectedCity} setPostOffice={setSelectedPostOffice} />
                                        {selectedRegion.ref.length > 0 && (
                                            <NpOption url={`/api/np/getCitiesByRegion`} setItems={setItems} items={items} setItemsAreLoading={setCitiesAreLoading} regionRef={selectedRegion.ref} divRef={refCities} placeholder={"Оберіть місто"}
                                                setShowItems={setShowCities} showItems={showCities} itemsAreLoading={cititesAreLoading} selectedItem={selectedCity} setSelectedItem={setSelectedCity} />
                                        )}
                                        {selectedCity.ref.length > 0 && selectedRegion.ref.length > 0 && (
                                            <div className="space-y-3">
                                                <NpOption url={`/api/np/getStreetsByCity`} setItems={setItems} items={items} setItemsAreLoading={setStreetsAreLoading} cityRef={selectedCity.ref} divRef={refStreets} placeholder={"Оберіть вулицю"}
                                                    setShowItems={setShowStreets} showItems={showStreets} itemsAreLoading={streetsAreLoading} selectedItem={selectedStreet} setSelectedItem={setSelectedStreet} />
                                                <div className="w-full flex flex-row text-center justify-start items-center text-center space-x-4">
                                                    <input id="houseId" type="number" placeholder="Дім" value={house} onChange={e => setHouse(e.target.value)}
                                                        className={`outline-none block p-2 w-2/3 text-xl text-gray-900 bg-gray-50 rounded-lg border-gray-300 select-none shadow-md ${!showHouseValidation ? "ring-2 ring-red-500" : "ring-0"}`}
                                                    />
                                                    <input id="appartmentId" type="number" placeholder="Кв/Офіс" value={appartment} onChange={e => setAppartment(e.target.value)}
                                                        className={`outline-none block p-2 w-1/3 text-xl text-gray-900 bg-gray-50 rounded-lg border-gray-300 select-none shadow-md`}
                                                    />
                                                </div>
                                            </div>
                                        )}
                                    </div>
                                )}
                            </div>
                        </div>
                    </div>
                    <div className="w-full items-center flex justify-center">
                        <div className="w-[360px] sm:w-[500px] lg:w-11/12 xl:w-5/6 h-auto flex items-center flex-col rounded-xl space-y-3 pb-4">
                            <button className="bg-[#3ba144] w-72 h-16 rounded-full text-white p-2 text-xl drop-shadow-xl font-semibold  hover:bg-green-700 hover:ease-in hover:duration-300 duration-300 text-center"
                                onClick={() => {
                                    if (validateInputs() && !validateCart()) {
                                        if (selectCourier && house.length > 0) {
                                            updateOrderByUserToken();
                                        }
                                        else if (selectPostOffice || selectPostOfficeHouse) {
                                            updateOrderByUserToken();
                                        }
                                    }
                                }}>
                                Оформити замовлення
                            </button>
                        </div>
                    </div>
                </div>
            }
        </div>
    );
}