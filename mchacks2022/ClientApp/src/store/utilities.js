export const arrayToDictionary = (array, keyId = 'id') =>
    array.reduce((dict, node) =>
        Object.assign(dict, {[node[keyId]]: node}), {});