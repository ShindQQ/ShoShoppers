export const InputWithValidation = ({textOption, placeholder, inputValue, showValidation }) => {
    return (
        <div className="w-full flex flex-row text-center justify-start items-center text-center">
            <p className="w-48 sm:w-40 text-start">{textOption}</p>
            <input placeholder={placeholder} ref={inputValue}
                className={`outline-none block p-2 w-full text-xl text-gray-900 bg-gray-50 rounded-lg border-gray-300 select-none shadow-md ${!showValidation ? "ring-2 ring-red-500" : "ring-0"}`}
            />
        </div>
    );
}