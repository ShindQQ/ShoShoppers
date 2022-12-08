import { useEffect } from 'react';
import { React, useState } from 'react';
import { CartState } from '../../context/Context';
import { checkAddOption } from '../ItemsForSaleRendering/RenderItems';
import { SetItems, checkItemsAmmount } from './itemsAmmountCheck';

export const RenderCartItems = ({ style, orderOption }) => {
    const {
        state: { cart },
        dispatch,
    } = CartState();

    const [shoppersAndPins, setShoppersAndPins] = useState([]);

    useEffect(() => {
        SetItems(setShoppersAndPins);
    }, [])

    return (
        <ul className={style} >
            {cart.map((item) => {
                const check = checkItemsAmmount(shoppersAndPins, item);
                return (
                    <li className="h-32 w-full flex items-center p-2 px-2 pb-3 border-b-[2px] border-gray-200" key={item.id} >
                        <img alt="/" loading="lazy" src={`${item.imageLink}`} className="object-contain h-28 w-auto rounded-xl drop-shadow-md brightness-[1.02]"></img>
                        <div className={`${orderOption ? "flex-col sm:flex-row" : "flex-col"} flex items-center justify-top text-center align-center w-full relative h-full`}>
                            <p className={`${orderOption ? "w-auto sm:w-1/3" : "w-auto pb-2"} text-black text-xl font-bold `}> {item.name} </p>
                            <p className={`${orderOption ? "w-auto sm:w-1/3" : "w-auto"} text-black text-lg`}> {item.price} грн </p>
                            <div className={`${orderOption ? "w-auto sm:w-1/3" : "w-auto"} text-black`}>
                                <button className="text-2xl font-bold w-6" onClick={(e) => item.qty !== 1 ? dispatch({
                                    type: "CHANGE_CART_QTY",
                                    payload: { id: item.id, qty: item.qty - 1, },
                                }) : dispatch({ type: "REMOVE_FROM_CART", payload: item, })}>
                                    <span>-</span>
                                </button>
                                <span className="px-2 text-xl w-6"> {item.qty} </span>
                                <button className={`text-2xl font-bold w-6 ${checkAddOption(cart, item) ? "" : "text-red-500 font-black"}`}
                                    onClick={(e) => {
                                        if (checkAddOption(cart, item)) {
                                            dispatch({
                                                type: "CHANGE_CART_QTY",
                                                payload: { id: item.id, qty: item.qty + 1, },
                                            })
                                        }
                                    }}>
                                    <span>+</span>
                                </button>
                            </div>
                            <p className={`${check ? "block" : "hidden"} ${orderOption ? "-bottom-2 ml-2 sm:ml-0 w-full" : "-bottom-3"} text-lg absolute text-red-500 `}>Товар закінчився!</p>
                        </div>
                        <div className="flex justify-center items-center h-full">
                            <button className="flex justify-center items-center border-2 rounded-full shadow-lg"
                                onClick={() => dispatch({ type: "REMOVE_FROM_CART", payload: item, })}>
                                <svg className={`${check ? "text-red-500" : "text-black"} h-10 w-10 rounded`} fill="currentColor" viewBox="0 0 24 24" aria-hidden="true">
                                    <path fillRule="evenodd"
                                        d="M8.818,15.889l7.071,-7.071c0.195,-0.195 0.195,-0.512 0,-0.707c-0.195,-0.195 -0.512,-0.195 -0.707,-0l-7.071,7.071c-0.195,0.195 -0.195,0.512 -0,0.707c0.195,0.195 0.512,0.195 0.707,0Z"
                                        clipRule="evenodd" />
                                    <path fillRule="evenodd"
                                        d="M15.889,15.182l-7.071,-7.071c-0.195,-0.195 -0.512,-0.195 -0.707,-0c-0.195,0.195 -0.195,0.512 -0,0.707l7.071,7.071c0.195,0.195 0.512,0.195 0.707,0c0.195,-0.195 0.195,-0.512 0,-0.707Z"
                                        clipRule="evenodd" />
                                </svg>
                            </button>
                        </div>
                    </li>
                )
            })}
        </ul>
    );
}