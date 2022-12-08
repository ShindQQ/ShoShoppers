import { CartState } from '../../context/Context';

export const Search = ({showFilterResult, setShowFilterResult}) => {
    const {
        itemsDispatch,
    } = CartState();

    return (
        <div className="block relative drop-shadow-lg rounded-lg">
            <input text="text" placeholder="Шо?Шопер!"
                className="outline-none block p-2 w-full text-xl text-gray-900 bg-gray-50 rounded-lg border-gray-300 select-none"
                onChange={(e) => {
                    itemsDispatch({ type: "FILTER_BY_SEARCH", payload: e.target.value });
                    showFilterResult ? setShowFilterResult(false) : setShowFilterResult(true);
                }} />
        </div>
    );
}