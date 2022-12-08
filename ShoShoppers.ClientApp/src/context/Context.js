import { createContext, useContext, useEffect, useReducer } from "react";
import { cartReducer, itemsReducer } from "./Reducers";

const Cart = createContext();

const Context = ({children}) => {
    const [state, dispatch] = useReducer(cartReducer, {
        cart: JSON.parse(localStorage.getItem("cart")) || [],
        showIndividual: JSON.parse(localStorage.getItem("showIndividual")) || false,
        showShoppers: JSON.parse(localStorage.getItem("showShoppers")) || false,
        showPins: JSON.parse(localStorage.getItem("showPins")) || false
    })

    const [itemsState, itemsDispatch] = useReducer(itemsReducer, {
        searchQuery: "",
        byItemsColors: [],
        byItemsImagesColors: [],
        sortByAscending: false,
        sortByDescending: false,
    });


    useEffect(() => {
        if (localStorage.getItem("cart") == null) {
            state.cart = [];
        } 
        localStorage.setItem("cart", JSON.stringify(state.cart));
        localStorage.setItem("showIndividual", JSON.stringify(state.showIndividual));
        localStorage.setItem("showShoppers", JSON.stringify(state.showShoppers));
        localStorage.setItem("showPins", JSON.stringify(state.showPins));
    }, [state, state.cart, state.showIndividual, state.showShoppers, state.showPins]);

    return (
        <Cart.Provider value={{state, dispatch, itemsState, itemsDispatch}}>
            {children}
        </Cart.Provider>
    )
}

export const CartState = () => {
    return useContext(Cart);
}

export default Context;