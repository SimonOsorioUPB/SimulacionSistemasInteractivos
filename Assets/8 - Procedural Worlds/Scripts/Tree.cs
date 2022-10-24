using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject branchPrefab;
    private new Transform transform;
    
    [SerializeField] private int totalLevels = 3;
    [SerializeField] private float initialSize= 5f;
    [SerializeField, Range(0, 1)] private float reductionPerLevel = 0.1f;
    
    private const int IndexOfSquareChild = 0;
    private const int IndexOfCircleChild = 1;

    private int currentLevel=1;
    private Queue<GameObject> rootBranchesQueue;

    void Start()
    {
        rootBranchesQueue = new Queue<GameObject>();
        transform = GetComponent<Transform>();
        GameObject root = Instantiate(branchPrefab, transform);
        root.name = "Branch [Root]";
        ChangeBranchSize(root, initialSize);
        rootBranchesQueue.Enqueue(root);
        GenerateTree();
    }

    private float GetBranchLength(GameObject branchInstance)
    {
        return branchInstance.transform.GetChild(IndexOfSquareChild).localScale.y;
    }

    private GameObject CreateBranch(GameObject previousBranch, float relativeAngle)
    {
        GameObject newBranch = Instantiate(branchPrefab, transform);
        newBranch.transform.localPosition = previousBranch.transform.localPosition + previousBranch.transform.up * GetBranchLength(previousBranch);
        newBranch.transform.localRotation = previousBranch.transform.localRotation * Quaternion.Euler(0, 0, relativeAngle);

        return newBranch;
    }
    
    private void ChangeBranchSize(GameObject branchInstance, float newSize)
    {
        Transform square = branchInstance.transform.GetChild(IndexOfSquareChild);
        Transform circle = branchInstance.transform.GetChild(IndexOfCircleChild);

        //Change square scale
        Vector3 newScale = square.localScale; 
        newScale.y = newSize;
        square.localScale = newScale;

        //Change square position
        Vector3 newPosition = square.localPosition;
        newPosition.y = newSize/2;
        square.localPosition = newPosition;

        //Change circle position
        Vector3 newCirclePosition = circle.localPosition;
        newCirclePosition.y = newSize;
        circle.localPosition = newCirclePosition;
    }
    
    private void GenerateTree()
    {
        if (currentLevel >= totalLevels) return;
        ++currentLevel;

        float newSize = Mathf.Max(initialSize - initialSize * reductionPerLevel*(currentLevel-1), 0.1f);
        var branchesCreatedThisCycle = new List<GameObject>();

        while (rootBranchesQueue.Count > 0)
        {
            var rootBranch = rootBranchesQueue.Dequeue();

            var leftBranch = CreateBranch(rootBranch, Random.Range(5f, 25f));
            var rightBranch = CreateBranch(rootBranch, -Random.Range(5f, 25f));

            ChangeBranchSize(leftBranch, newSize);
            ChangeBranchSize(rightBranch, newSize);

            branchesCreatedThisCycle.Add(leftBranch);
            branchesCreatedThisCycle.Add(rightBranch);
        }
        foreach (var newBranches in branchesCreatedThisCycle) rootBranchesQueue.Enqueue(newBranches);
        
        GenerateTree();
    }
}
