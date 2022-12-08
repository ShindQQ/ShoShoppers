import { React } from 'react';
import { CartState } from '../../context/Context';
import { totalQuantity, totalProductionQuantity } from '../Cart/Cart';

export const RenderCartResult = ({ style, showButton }) => {
    const {
        state: { cart },
    } = CartState();

    return (
        <div className={`${style}`}>
            <p>Товарів в корзині: {totalQuantity(cart)}</p>
            {totalProductionQuantity(cart) > 0 &&
                (<p className="mt-2 drop-shadow-lg">Термін виготовлення: {totalProductionQuantity(cart)}-{Math.round(1.5 * totalProductionQuantity(cart))} дні/днів</p>)
            }
            <p className="mt-2 pb-2 drop-shadow-lg">Загальна вартість: {cart.reduce(function (sum, current) {
                return sum + Number(current.price * current.qty);
            }, 0)} грн</p>
            {showButton && <button className="w-full mx-auto bg-[#3ba144] w-64 h-10 my-4 rounded-xl text-white drop-shadow-lg mt-3">
                <a href="/order">Оформити замовлення</a>
            </button>}
        </div>
    );
}