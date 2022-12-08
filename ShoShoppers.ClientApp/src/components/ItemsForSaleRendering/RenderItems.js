import { useState, useEffect } from 'react';
import { CartState } from '../../context/Context';
import { generateUserUniqueToken } from '../OrdersPage/generateUserUniqueToken';

export const checkAddOption = (cart, item) => {
    let cartItems = cart.find((c) => c.id === item.id);

    return item.itemAmmount < 0 || cartItems === undefined || cartItems.qty !== item.itemAmmount;
}

export const RenderItems = ({ items, _showFilterResult }) => {
    const {
        state: { cart },
        dispatch,
        itemsState: { searchQuery, byItemsColors, byItemsImagesColors, sortByAscending, sortByDescending },
    } = CartState();

    const [showCartAdded, setShowCartAdded] = useState(false);
    const [showMaxItemAmmount, setShowMaxItemAmmount] = useState(false);

    useEffect(() => {
        const itemsTimer = setTimeout(function () {
            setShowCartAdded(false);
            setShowMaxItemAmmount(false);
        }, 3000);

        return () => {
            clearTimeout(itemsTimer);
        }
    }, [showCartAdded, showMaxItemAmmount])

    const transformItems = () => {
        let sortedItems = [...items];

        sortedItems = sortedItems.filter(item => item.itemAmmount !== 0);

        if (sortByAscending) {
            sortedItems = sortedItems.sort((a, b) => a.price - b.price);
        }

        if (sortByDescending) {
            sortedItems = sortedItems.sort((a, b) => b.price - a.price);
        }

        if (searchQuery) {
            sortedItems = sortedItems.filter(item => item.name.toLowerCase().includes(searchQuery.toLowerCase()));
        }

        if (byItemsColors.length > 0) {
            sortedItems = sortedItems.filter(item => byItemsColors.map(item => item.itemColorText).includes(item.color));
        }

        if (byItemsImagesColors.length > 0) {
            sortedItems = sortedItems.filter(item => byItemsImagesColors.map(item => item.itemColorText).every(itemsColor => item.imageColor.includes(itemsColor)));
        }

        return sortedItems;
    }

    const totalAmmountZeroQuantity = () => {
        return transformItems().filter(item => item.itemAmmount === 0).length;
    }

    return (
        <div className="w-full">
            <div className={`fixed w-auto top-[60px] right-0 flex justify-end items-center z-40 transition-all duration-300 origin-top-right ${showCartAdded ? " scale-100" : "scale-0"}`}>
                <div className="text-2xl font-semibold w-80 h-28 bg-white text-center flex justify-center items-center rounded-b-[3rem] shadow-xl">
                    <div className="drop-shadow-xl">
                        {showMaxItemAmmount ?
                            <p>Товар закінчився</p> :
                            <div className="pt-2">
                                <p>Додано в кошик</p>
                                <a href="/order">
                                    <button className="w-full mx-auto bg-[#3ba144] w-64 h-10 my-2 rounded-xl text-white drop-shadow-lg text-xl">
                                        Оформити замовлення
                                    </button>
                                </a>
                            </div>
                        }
                    </div>
                </div>
            </div>
            <div className={`fixed w-auto top-[60px] left-0 flex justify-start items-center z-40  transition-all duration-300 origin-top-left ${_showFilterResult ? " scale-100" : "scale-0"}`}>
                <div className="text-2xl font-semibold w-64 h-16 bg-white text-center flex justify-center items-center rounded-b-[3rem] shadow-xl">
                    <div className="drop-shadow-xl">
                        {transformItems().length === 0 ?
                            <p>Нічого не знайдено</p> :
                            <p>Знайдено {transformItems().length}</p>
                        }
                    </div>
                </div>
            </div>
            {totalAmmountZeroQuantity() !== transformItems().length ?
                (<div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 justify-center items-center my-auto bg-transparent w-full px-4 2xl:px-2">
                    {transformItems().map((item) => (
                        item.itemAmmount !== 0 &&
                        <div className="group relative flex text-center justify-center align-center items-center mb-16 bg-transparent p-2" key={item.id}>
                            <div className="group flex justify-center align-center items-center w-auto relative">
                                <img loading="lazy" className="w-96 h-full inline drop-shadow-xl select-none" src={item.imageLink} alt="/" />
                                <div className="absolute text-transition top-0 bg-transparent w-full h-full justify-center text-center text-xl font-bold pt-8 px-4 text-slate-100 drop-shadow-2xl select-none">
                                    {item.description}
                                </div>
                            </div>
                            <button onClick={() => {
                                if (checkAddOption(cart, item)) {
                                    if (cart.find((c) => c.id === item.id) === undefined) {
                                        dispatch({
                                            type: "ADD_TO_CART",
                                            payload: item,
                                        })

                                        if (localStorage.getItem("tokenExpirationTime") == null) {
                                            generateUserUniqueToken();
                                            localStorage.setItem("tokenExpirationTime", new Date().getTime())
                                        }
                                    }
                                    else {
                                        dispatch({
                                            type: "CHANGE_CART_QTY",
                                            payload: {
                                                id: cart.find((c) => c.id === item.id).id,
                                                qty: cart.find((c) => c.id === item.id).qty + 1,
                                            },
                                        })
                                    }
                                }
                                else {
                                    if (cart.find((c) => c.id === item.id) === undefined) {
                                        dispatch({
                                            type: "ADD_TO_CART",
                                            payload: item,
                                        })

                                        if (localStorage.getItem("tokenExpirationTime") == null) {
                                            generateUserUniqueToken();
                                            localStorage.setItem("tokenExpirationTime", new Date().getTime())
                                        }
                                    }
                                    else {
                                        setShowMaxItemAmmount(true);
                                    }
                                }
                                setShowCartAdded(true);
                            }}
                                className="-mb-4 absolute bottom-0 w-32 h-10 text-white bg-[#3ba144] font-medium rounded-lg text-xl z-10 my-auto shadow-xl cursor-pointer items-center text-center hover:bg-green-700 hover:ease-in hover:duration-300 duration-300 text-center flex justify-center items-center">
                                <p className="drop-shadow-lg select-none w-20">{item.price} грн</p>
                            </button>
                            <p className="h-20 absolute bottom-2 w-full pt-3 -my-24 text-3xl text-[#3ba144] z-2 font-medium drop-shadow-lg">{item.name}</p>
                        </div>
                    ))}
                </div>) : (
                    <div className="w-full text-center items-center flex justify-center text-3xl text-semibold text-[#3ba144] drop-shadow-lg">
                        <p>Наразі нічого немає в наявності</p>
                    </div>
                )}
        </div>
    );
}