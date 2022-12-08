export const cartReducer = (state, action) => {
    switch (action.type) {
        case "ADD_TO_CART":
            return { ...state, cart: [...state.cart, { ...action.payload, qty: 1 }] };
        case "REMOVE_FROM_CART":
            return {
                ...state,
                cart: state.cart.filter((c) => c.id !== action.payload.id),
            };
        case "REMOVE_CART":
            return {
                ...state,
                cart: [],
            };
        case "CHANGE_CART_QTY":
            return {
                ...state,
                cart: state.cart.filter((c) =>
                    c.id === action.payload.id ? (c.qty = action.payload.qty) : c.qty
                ),
            };
        case "GO_TO_INDIVIDUAL":
            return {
                ...state,
                showIndividual: true,
                showShoppers: false,
                showPins: false
            };
        case "GO_TO_SHOPPERS":
            return {
                ...state,
                showIndividual: false,
                showShoppers: true,
                showPins: false
            };
        case "GO_TO_PINS":
            return {
                ...state,
                showIndividual: false,
                showShoppers: false,
                showPins: true
            };
        case "GO_TO_MAIN":
            return {
                ...state,
                showIndividual: false,
                showShoppers: false,
                showPins: false
            };
        default:
            return state;
    }
};

export const itemsReducer = (state, action) => {
    switch (action.type) {
        case "ADD_TO_FILTER_BY_COLOR":
            return { ...state, byItemsColors: [...state.byItemsColors, { ...action.payload }] };
        case "REMOVE_FROM_FILTER_BY_COLOR":
            return { ...state, byItemsColors: state.byItemsColors.filter((c) => c.itemColorText !== action.payload.itemColorText), };
        case "ADD_TO_FILTER_BY_IMAGE_COLOR":
            return { ...state, byItemsImagesColors: [...state.byItemsImagesColors, { ...action.payload }] };
        case "REMOVE_FROM_FILTER_BY_IMAGE_COLOR":
            return { ...state, byItemsImagesColors: state.byItemsImagesColors.filter((c) => c.itemColorText !== action.payload.itemColorText), };
        case "FILTER_BY_SEARCH":
            return { ...state, searchQuery: action.payload };
        case "SORT_ASCENDING":
            return { ...state, sortByAscending: action.payload };
        case "SORT_DESCENDING":
            return { ...state, sortByDescending: action.payload };
        default:
            return state;
    }
}