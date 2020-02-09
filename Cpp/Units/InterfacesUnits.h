#ifndef LOGICDLL_INTERFACESUNITS_H
#define LOGICDLL_INTERFACESUNITS_H

class IMovable
{
public:
    virtual ~IMovable() {}
    virtual void Move() = 0;
};

class ISelectable
{
public:
    virtual ~ISelectable() {}
    virtual void Select() = 0;
};

#endif

/*class IHealth
{
public:
    virtual ~IHealth() {}
    virtual void Damage() = 0;
};
*/
