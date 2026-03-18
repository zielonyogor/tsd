#include <iostream>
#include <vector>
#include <stdexcept>
#include <random>

template <typename T> class RandomCollection {

private:
    std::vector<T> items;
    std::mt19937 rng;

public:
    RandomCollection() : rng(std::random_device{}()) {}

    void add(const T& item) {
        items.push_back(item);
    }

    T get(int index) {
        if (index < 0 || index >= items.size()) {
            throw std::out_of_range("Index out of range");
        }

        std::uniform_int_distribution<int> dist(0, index);
        return items[dist(rng)];
    }

    bool isEmpty() const {
        return items.empty();
    }
};